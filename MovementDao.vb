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
'    Console.WriteLine(" Save Record : register pos : " & registerPos)

    If isNewRecord = True Then
      dr = dt.NewRow()
      dt.Rows.Add(dr)
      registerPos = dt.Rows.Count - 1
    End If

' Console.WriteLine(" Save Record 2 : register pos : " & registerPos)

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
      Console.WriteLine("MovementDao.vb:SaveDataInRecord() \n Element - " & recordList.Item(registerPos)(fieldsList.Keys(i)))
      dr(fieldsList.Keys(i)) = recordList.Item(registerPos)(fieldsList.Keys(i))
      i += 1
    End While
  End Sub

  Public Sub GetDistributionById(ByRef id As Integer, ByRef rd As OleDb.OleDbDataReader)
    Dim sql As String

    sql = " SELECT s.sec_name AS sector_name, s.hall AS sector_hall, ps.stock" +
          " FROM (movements p INNER JOIN prod_sectors ps ON p.id = ps.id_product)" +
          " INNER JOIN sectors s ON (s.id = ps.id_sector)" +
          " WHERE p.id = " & id
    dataBaseManager.ExecuteQuery(sql, rd)

    Console.WriteLine("sql : " & sql)
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

