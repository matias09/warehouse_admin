Public NotInheritable Class TypesDao
  Const TABLE_NAME As String = "types"
  Private recordList As ArrayList
  Private fieldsList As Hashtable
  Private dataBaseManager As DataBaseManager
  Private Shared typSingleton As TypesDao = Nothing

  Dim da As OleDb.OleDbDataAdapter
  Dim cb As OleDb.OleDbCommandBuilder
  Dim dt As DataTable
  Dim dr As DataRow
  Dim registerPos As Integer = 0


  Public Shared ReadOnly Property GetInstance()
    Get
      If (typSingleton Is Nothing) Then
        typSingleton = New TypesDao()
      End If

      Return typSingleton
    End Get
  End Property

  Public Sub New()
    recordList = New ArrayList()
    fieldsList = New Hashtable()
    dataBaseManager = dataBaseManager.GetInstance()

    fieldsList.Add("typ_name", "")
    fieldsList.Add("codint", "")

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
      fieldsList("typ_name") = dr("typ_name")
      fieldsList("codint") = dr("codint")
      recordList.Add(fieldsList)
      i += 1
    End While
  End Sub

  Public Sub EraseRecord()
    dataBaseManager.EraseRecord(registerPos, da, dt)
  End Sub

  Public Sub SaveRecord(ByVal isNewRecord As Boolean)
    Console.WriteLine(" Save Record : register pos : " & registerPos)

    If isNewRecord = True Then
      dr = dt.NewRow()
      dt.Rows.Add(dr)
      registerPos = dt.Rows.Count - 1
    End If

    Console.WriteLine(" Save Record 2 : register pos : " & registerPos)

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
      Console.WriteLine("Element - " & recordList.Item(registerPos)(fieldsList.Keys(i)))
      dr(fieldsList.Keys(i)) = recordList.Item(registerPos)(fieldsList.Keys(i))
      i += 1
    End While
  End Sub
End Class
