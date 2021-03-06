﻿Public NotInheritable Class ProductsDao
  Const TABLE_NAME As String = "products"
  Const PRODUCTS_SECTORS_TABLE_NAME As String = "prod_sectors"
  Const SECTORS_TABLE_NAME As String = "sectors"
  Private recordList As ArrayList
  Private fieldsList As Hashtable
  Private dataBaseManager As DataBaseManager
  Private Shared proSingleton As ProductsDao = Nothing

  Dim da As OleDb.OleDbDataAdapter
  Dim cb As OleDb.OleDbCommandBuilder
  Dim dt As DataTable
  Dim dr As DataRow
  Dim registerPos As Integer = 0

  Public Shared ReadOnly Property GetInstance()
    Get
      If (proSingleton Is Nothing) Then
        proSingleton = New ProductsDao()
      End If

      Return proSingleton
    End Get
  End Property

  Public Sub New()
    recordList = New ArrayList()
    fieldsList = New Hashtable()
    dataBaseManager = dataBaseManager.GetInstance()

    fieldsList.Add("pro_name", "")
    fieldsList.Add("id_type", "")
    fieldsList.Add("stock", "")
    fieldsList.Add("state", "")

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
      fieldsList("pro_name") = dr("pro_name")
      fieldsList("id_type") = dr("id_type")
      fieldsList("stock") = dr("stock")
      fieldsList("state") = dr("state")
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

    fieldsCount = fieldsList.Count
    While i < fieldsCount
      dr(fieldsList.Keys(i)) = recordList.Item(registerPos)(fieldsList.Keys(i))
      i += 1
    End While
  End Sub

  Public Sub GetDistributionById(ByRef id As Integer, ByRef rd As OleDb.OleDbDataReader)
    Dim sql As String

    sql = " SELECT s.sec_name AS sector_name, s.hall AS sector_hall, ps.stock " +
          " FROM (products p INNER JOIN prod_sectors ps ON p.id = ps.id_product) " +
          " INNER JOIN sectors s ON (s.id = ps.id_sector) " +
          " WHERE p.id = " & id
    dataBaseManager.ExecuteQuery(sql, rd)
  End Sub

  Public Sub GetById(ByRef id As Integer, ByRef rd As OleDb.OleDbDataReader)
    Dim sql As String

    sql = " SELECT * " +
          " FROM products p " +
          " WHERE p.id = " & id
    dataBaseManager.ExecuteQuery(sql, rd)
  End Sub
End Class
