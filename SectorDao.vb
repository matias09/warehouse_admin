Public NotInheritable Class SectorsDao
  Const TABLE_NAME As String = "sectors"
  Const TABLE_NAME_PROD_SECTORS As String = "prod_sectors"

  Private recordList As ArrayList
  Private fieldsList As Hashtable
  Private dataBaseManager As DataBaseManager
  Private Shared secSingleton As SectorsDao = Nothing

  Dim da As OleDb.OleDbDataAdapter
  Dim cb As OleDb.OleDbCommandBuilder
  Dim dt As DataTable
  Dim dr As DataRow
  Dim registerPos As Integer = 0


  Public Shared ReadOnly Property GetInstance()
    Get
      If (secSingleton Is Nothing) Then
        secSingleton = New SectorsDao()
      End If

      Return secSingleton
    End Get
  End Property

  Public Sub New()
    recordList = New ArrayList()
    fieldsList = New Hashtable()
    dataBaseManager = dataBaseManager.GetInstance()

    fieldsList.Add("id", "")
    fieldsList.Add("sec_name", "")
    fieldsList.Add("hall", "")

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
      fieldsList("sec_name") = dr("sec_name")
      fieldsList("hall") = dr("hall")
      recordList.Add(fieldsList)
      i += 1
    End While
  End Sub

  Public Sub EraseRecord()
    dataBaseManager.EraseRecord(registerPos, da, dt)
  End Sub

  Public Sub SaveRecord(ByVal isNewRecord As Boolean)
    'Console.WriteLine("--MATIAS::SectorDao::SaveRecord - register pos : " & registerPos)

    If isNewRecord = True Then
      dr = dt.NewRow()
      dt.Rows.Add(dr)
      registerPos = dt.Rows.Count - 1
    End If

    'Console.WriteLine("--MATIAS::SectorDao::SaveRecord - 2 register pos : " & registerPos)

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

  Public Function HasProductsRelations(ByRef id As Integer) As Boolean
    Dim sql As String
    Dim dbConn As OleDb.OleDbConnection = dataBaseManager.GetConnectionInstance()
    Dim rd As OleDb.OleDbDataReader = Nothing

    sql = "SELECT id FROM " + TABLE_NAME_PROD_SECTORS +
          " WHERE id_sector = @id_sector"

    Dim cd As OleDb.OleDbCommand = New OleDb.OleDbCommand(sql, dbConn)
    cd.Parameters.Add("@id_sector", OleDb.OleDbType.Integer).Value = id

    rd = cd.ExecuteReader()

    cd.Dispose()
    Return rd.HasRows
  End Function

  ' Privates
  Private Sub SaveDataInRecord()
    Dim i As Integer = 0
    Dim fieldsCount As Integer = 0

    'Console.WriteLine("--MATIAS::SectorDao::SaveDataInRecord - register pos : " & registerPos)

    fieldsCount = fieldsList.Count
    While i < fieldsCount
      'Console.WriteLine("--MATIAS::SectorDao::SaveDataInRecord - Element - " & recordList.Item(registerPos)(fieldsList.Keys(i)))
      dr(fieldsList.Keys(i)) = recordList.Item(registerPos)(fieldsList.Keys(i))
      i += 1
    End While
  End Sub
End Class
