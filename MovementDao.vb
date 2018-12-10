Public NotInheritable Class MovementDao
  Const TABLE_NAME As String = "movements"
  Const TABLE_NAME_PRODUCTS As String = "products"
  Const TABLE_NAME_PROD_SECTORS As String = "prod_sectors"

  Private recordList As ArrayList
  Private fieldsList As Hashtable
  Private dataBaseManager As DataBaseManager
  Private Shared proSingleton As MovementDao = Nothing

  Dim da As OleDb.OleDbDataAdapter
  Dim cb As OleDb.OleDbCommandBuilder
  Dim dt As DataTable
  Dim dr As DataRow
  Dim registerPos As Integer = 0


  Public Shared ReadOnly Property GetInstance()
    Get
      If (proSingleton Is Nothing) Then
        proSingleton = New MovementDao()
      End If

      Return proSingleton
    End Get
  End Property

  Public Sub New()
    recordList = New ArrayList()
    fieldsList = New Hashtable()
    dataBaseManager = dataBaseManager.GetInstance()

    fieldsList.Add("id", "")
    fieldsList.Add("id_product", "")
    fieldsList.Add("id_sector", "")
    fieldsList.Add("count", "")
    fieldsList.Add("operation", "")
    fieldsList.Add("mov_date", "")

    dataBaseManager.PrepareDao(TABLE_NAME, da, cb, dt)
    FillRecordList()
  End Sub

  Private Sub FillRecordList()
    Dim rowsCount As Integer = 0
    Dim i As Integer = 0

    rowsCount = dt.Rows.Count
    While i < rowsCount
      fieldsList = New Hashtable()
      dr = dt.Rows(i)
      fieldsList("id") = dr("id")
      fieldsList("id_product") = dr("id_product")
      fieldsList("id_sector") = dr("id_sector")
      fieldsList("count") = dr("count")
      fieldsList("operation") = dr("operation")
      fieldsList("mov_date") = dr("mov_date")
      recordList.Add(fieldsList)
      i += 1
    End While
  End Sub

  Public Sub EraseRecord()
    dataBaseManager.EraseRecord(registerPos, da, dt)
  End Sub

  Public Sub SaveRecord(ByVal isNewRecord As Boolean)
    If isNewRecord = True Then
      dr = dt.NewRow()
      dt.Rows.Add(dr)
      registerPos = dt.Rows.Count - 1
    End If

    dr = dt.Rows(registerPos)
    SaveDataInRecord()
  End Sub

  ' Get Functions
  Public Function GetFields() As Hashtable
    Return fieldsList
  End Function

  Public Function GetRecords() As ArrayList
    Return recordList
  End Function

  Public Function GetRegisterPos() As Integer
    Return registerPos
  End Function

  ' Set Functions
  Public Sub SetRecordList(ByRef records As ArrayList)
    recordList = records
  End Sub

  Public Sub SetRegisterPos(ByVal newRegisterPos As Integer)
    registerPos = newRegisterPos
  End Sub

  ' Privates
  Private Sub SaveDataInRecord()
    Dim i As Integer = 0
    Dim fieldsCount As Integer = 0

    Console.WriteLine(" -- MATIAS -- Save Data in Record : register pos : " & registerPos)

    fieldsCount = fieldsList.Count
    While i < fieldsCount
'      Console.WriteLine("MovementDao.vb:SaveDataInRecord() Element {1} = {0}", recordList.Item(registerPos)(fieldsList.Keys(i)), fieldsList.Keys(i))

      dr(fieldsList.Keys(i)) = recordList.Item(registerPos)(fieldsList.Keys(i))
      i += 1
    End While
  End Sub

  Public Sub InsertNewRecord(ByRef data As Hashtable)

    Console.WriteLine("  -- MATIAS -- InsertNewRecord() -- ")

    Dim stock As Integer = 0
    Dim id_product As Integer = data("id_product")
    Dim id_sector As Integer = data("id_sector")
    Dim sql As String = ""
    Dim dbConn As OleDb.OleDbConnection = dataBaseManager.GetConnectionInstance()

    sql = "INSERT INTO " + TABLE_NAME + " VALUES(@id, @id_product, @id_sector, @count, @operation, @mov_date)"

    ' Insert into Movements
    Dim cd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, dbConn)
    cd.Parameters.Add("@id", OleDb.OleDbType.Integer).Value = data("id")
    cd.Parameters.Add("@id_product", OleDb.OleDbType.Integer).Value = id_product
    cd.Parameters.Add("@id_sector", OleDb.OleDbType.Integer).Value = id_sector
    cd.Parameters.Add("@count", OleDb.OleDbType.Integer).Value = data("count")
    cd.Parameters.Add("@operation", OleDb.OleDbType.Char).Value = data("operation")
    cd.Parameters.Add("@mov_date", OleDb.OleDbType.Date).Value = data("mov_date")

    cd.ExecuteReader()
    cd.Dispose()

    ' Product Sectors
    stock = GetProductSectorStock(id_product, id_sector, dbConn)
    If (stock > 0) Then
      stock += data("count")
      UpdateProdSectorsTable(stock, id_product, id_sector, dbConn)
    Else
      InsertIntoProductSectorTable(data("count"), id_product, id_sector, dbConn)
    End If

    ' Product
    UpdateStockOnProductTable(data("count"), id_product, dbConn)
  End Sub

  Private Sub InsertIntoProductSectorTable(ByRef stock As Integer, ByRef id_product As Integer, ByRef id_sector As Integer, ByRef dbConn As OleDb.OleDbConnection)

    Console.WriteLine("-- MATIAS -- InsertIntoProductSectorTable() -- ")

   Dim id As Integer = 1
   Dim sql As String = ""
   Dim rd As OleDb.OleDbDataReader = Nothing

   sql = "SELECT TOP 1 id FROM " + TABLE_NAME_PROD_SECTORS + " ORDER BY id DESC"
   Dim cd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, dbConn)

   rd = cd.ExecuteReader()
   If rd.HasRows = True Then
     While rd.Read()
       id = rd.Item("id") + 1
     End While

     rd.Close()
   End If
   cd.Dispose()

    sql = "INSERT INTO " + TABLE_NAME_PROD_SECTORS + " VALUES(@id, @id_product, @id_sector, @stock)"

    ' Insert into Movements
    cd = New OleDb.OleDbCommand(sql, dbConn)
    cd.Parameters.Add("@id", OleDb.OleDbType.Integer).Value = id
    cd.Parameters.Add("@id_product", OleDb.OleDbType.Integer).Value = id_product
    cd.Parameters.Add("@id_sector", OleDb.OleDbType.Integer).Value = id_sector
    cd.Parameters.Add("@stock", OleDb.OleDbType.Integer).Value = stock

    cd.ExecuteReader()
    cd.Dispose()
  End Sub

  Private Sub UpdateProdSectorsTable(ByRef stock As Integer, ByRef id_product As Integer, ByRef id_sector As Integer, ByRef dbConn As OleDb.OleDbConnection)

    Console.WriteLine("-- MATIAS -- UpdateProdSectorsTable() -- ")

    Dim sql As String = ""
    sql = "UPDATE " + TABLE_NAME_PROD_SECTORS +
          " SET stock = @stock " +
          " WHERE id_product = @id_product AND id_sector = @id_sector"

    ' Insert into Movements
    Dim cd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, dbConn)
    cd.Parameters.Add("@stock", OleDb.OleDbType.Integer).Value = stock
    cd.Parameters.Add("@id_product", OleDb.OleDbType.Integer).Value = id_product
    cd.Parameters.Add("@id_sector", OleDb.OleDbType.Integer).Value = id_sector

    cd.ExecuteNonQuery()
    cd.Dispose()
  End Sub

  Private Sub UpdateStockOnProductTable(ByRef stock As Integer, ByRef id_product As Integer, ByRef dbConn As OleDb.OleDbConnection)

    Console.WriteLine("-- MATIAS -- UpdateStockOnProductTable() -- ")

    Dim sql As String = ""
    Dim old_stock As Integer = 0

    sql = "SELECT stock FROM " + TABLE_NAME_PRODUCTS +
          " WHERE id = @id_product"

    Dim cd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, dbConn)
    cd.Parameters.Add("@id_product", OleDb.OleDbType.Integer).Value = id_product

    rd = cd.ExecuteReader()
    If rd.HasRows = True Then
      While rd.Read()
       old_stock += rd.Item("stock")
      End While

      rd.Close()
    End If
    cd.Dispose()

    sql = "UPDATE " + TABLE_NAME_PRODUCTS +
          " SET stock = @stock " +
          " WHERE id = @id_product"

    ' Insert into Movements
    cd = New OleDb.OleDbCommand(sql, dbConn)
    cd.Parameters.Add("@stock", OleDb.OleDbType.Integer).Value = stock + old_stock
    cd.Parameters.Add("@id_product", OleDb.OleDbType.Integer).Value = id_product

    cd.ExecuteNonQuery()
    cd.Dispose()
  End Sub


  Private Function GetProductSectorStock(ByRef id_product As Integer, ByRef id_sector As Integer, ByRef dbConn As OleDb.OleDbConnection) As Integer

    Console.WriteLine("-- MATIAS -- GetProductSectorStock() -- ")

    Dim stock As Integer = 0
    Dim sql As String
    Dim rd As OleDb.OleDbDataReader = Nothing

    sql = "SELECT stock FROM " + TABLE_NAME_PROD_SECTORS +
          " WHERE id_product = @id_product AND id_sector = @id_sector"

    Dim cd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, dbConn)
    cd.Parameters.Add("@id_product", OleDb.OleDbType.Integer).Value = id_product
    cd.Parameters.Add("@id_sector", OleDb.OleDbType.Integer).Value = id_sector

    rd = cd.ExecuteReader()

    Console.WriteLine("-- MATIAS -- hasRows:  " & rd.HasRows)
    If rd.HasRows = True Then
     While rd.Read()
       stock += rd.Item("stock")
     End While
     rd.Close()
      Return stock
    Else
      Return 0
    End If

    cd.Dispose()
  End Function
End Class