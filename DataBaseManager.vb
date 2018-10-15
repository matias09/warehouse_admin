Public NotInheritable Class DataBaseManager
    Const DATABASE_NAME As String = "STK.mdb"
    Private dbConn As OleDb.OleDbConnection
    Private Shared dataBaseSingleton As DataBaseManager = Nothing

    Public Shared ReadOnly Property GetInstance()
        Get
            If (dataBaseSingleton Is Nothing) Then
                dataBaseSingleton = New DataBaseManager()
            End If

            Return dataBaseSingleton
        End Get
    End Property

    Private Sub New()
        Dim database_path As String
        database_path = Application.StartupPath

        Console.WriteLine("DATABASE INICIADA")
        dbConn = New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & database_path & "\" & DATABASE_NAME)
        dbConn.Open()
    End Sub

    Public Sub PrepareDao(ByVal tableName As String, ByRef da As OleDb.OleDbDataAdapter, ByRef cb As OleDb.OleDbCommandBuilder, ByRef dt As DataTable)
        da = New OleDb.OleDbDataAdapter("SELECT * FROM " & tableName, dbConn)

        cb = New OleDb.OleDbCommandBuilder(da)
        da.UpdateCommand = cb.GetUpdateCommand
        da.InsertCommand = cb.GetInsertCommand
        da.DeleteCommand = cb.GetDeleteCommand
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        dt = New DataTable()
        da.Fill(dt)
    End Sub

    Public Sub EraseRecord(ByVal registerPos As Integer, ByRef da As OleDb.OleDbDataAdapter, ByRef dt As DataTable)
        dt.Rows(registerPos).Delete()
        SubmmitChanges(da, dt)
    End Sub

    Public Sub SubmmitChanges(ByRef da As OleDb.OleDbDataAdapter, ByRef dt As DataTable)
        da.Update(dt)
        dt.AcceptChanges()
    End Sub
End Class
