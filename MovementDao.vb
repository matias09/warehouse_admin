Public NotInheritable Class MovementDao
  Const TABLE_NAME As String = "movements"

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
    dataBaseManager.SubmmitChanges(da, dt)
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

    Console.WriteLine(" Save Data in Record : register pos : " & registerPos)

    fieldsCount = fieldsList.Count
    While i < fieldsCount
      Console.WriteLine("MovementDao.vb:SaveDataInRecord() Element {1} = {0}", recordList.Item(registerPos)(fieldsList.Keys(i)), fieldsList.Keys(i))

      dr(fieldsList.Keys(i)) = recordList.Item(registerPos)(fieldsList.Keys(i))
      i += 1
    End While
  End Sub

  Public Sub insert(ByRef data As Hashtable)
    Dim sql As String = "INSERT INTO movements VALUES(@id, @id_product, @id_sector, @count, @operation, @mov_date)"
    Dim dbConn As OleDb.OleDbConnection = dataBaseManager.GetConnectionInstance()

    Dim cd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, dbConn)
    cd.CommandText = sql
    cd.Parameters.Add("@id", OleDb.OleDbType.Integer).Value = data("id")
    cd.Parameters.Add("@id_product", OleDb.OleDbType.Integer).Value = data("id_product")
    cd.Parameters.Add("@id_sector", OleDb.OleDbType.Integer).Value = data("id_sector")
    cd.Parameters.Add("@count", OleDb.OleDbType.Integer).Value = data("count")
    cd.Parameters.Add("@operation", OleDb.OleDbType.Char).Value = data("operation")
    cd.Parameters.Add("@mov_date", OleDb.OleDbType.Date).Value = data("mov_date")

    cd.ExecuteReader()
    cd.Dispose()

    registerPos = dt.Rows.Count - 1
    SaveDataInRecord()
  End Sub

  Public Sub GetById(ByRef id As Integer, ByRef rd As OleDb.OleDbDataReader)
    Dim sql As String

    sql = " SELECT *" +
          " FROM movements p " +
          " WHERE p.id = " & id
    dataBaseManager.ExecuteQuery(sql, rd)

    Console.WriteLine("sql : " & sql)
  End Sub
End Class

