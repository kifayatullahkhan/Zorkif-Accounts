Imports System.Data.SqlClient
Module MainModule
   

    Public Function connectionopen()
        Try
            If con.State = ConnectionState.Open Then
                Return True
                Exit Function
            End If
            'For Sql Server Express Edition ConnectionString
            ' con.ConnectionString = "data Source=.\SQLEXPRESS;database=Point_Of_Sale;Persist Security Info=True;User Id=sa;Password=ILOVEPAKISTANWHOAMI_2246" ';User Instance=true"
            'For Sql Server Standard Edition ConnectionString
            con.ConnectionString = "data Source=.;database=Accounting;Persist Security Info=True;User Id=sa;Password=ILOVEPAKISTANWHOAMI_2246" ';User Instance=true"

            'If vServerName.Length = 0 Then
            '    MsgBox("Please Enter ServerName or IP Address", MsgBoxStyle.OkOnly, "ServerName or IP Address Required")
            '    'cn.ConnectionString = "data Source=.;database=PrisonManagmentSystem;Persist Security Info=True;User Id=sa;Password=GETNPUT_WHOAMI_78" ';User Instance=true"
            'Else
            '    con.ConnectionString = "data Source=" & vServerName & ";database=PrisonManagmentSystem;Persist Security Info=True;User Id=sa;Password=ILOVEPAKISTANWHOAMI_2246" ';User Instance=true"
            'End If
            con.Open()
            Return True
            con.Close()
        Catch ex As Exception
            MsgBox("Unable to connected to the SQLServer " & vServerName & vbCrLf & "Please Try Correct ServerName or IP Address and Instant Name if required", MsgBoxStyle.Critical, "Connection not Found")
            Return False
        End Try
    End Function
    'Public Function LoadTble(ByVal Source As String, ByVal cmd As SqlCommand, ByVal DAP As SqlDataAdapter) As DataTable
    '    connectionopen()
    '    Dim tbl As New DataTable
    '    cmd.CommandText = Source
    '    cmd.Connection = Cn
    '    DAP.SelectCommand = cmd
    '    tbl.Clear()
    '    DAP.Fill(tbl)
    '    Return tbl
    'End Function
    Public Sub DatasetFill(ByVal query As String, ByVal table As String)
        Try
            connectionopen()
            cmd.Connection = con
            cmd.CommandText = query
            da.SelectCommand = cmd
            If ds.Tables.Contains(table) Then
                ds.Tables(table).Clear()
            End If
            da.Fill(ds, table)
        Catch ex As Exception

        End Try
    End Sub


    Public Function LoadTble(ByVal Source As String, ByVal cmd As SqlCommand, ByVal Dap As SqlDataAdapter) As DataTable

        Call connectionopen()
        Dim Tbl As New DataTable
        cmd.CommandText = Source
        cmd.Connection = con
        Dap.SelectCommand = cmd

        Tbl.Clear()
        Dap.Fill(Tbl)

        Return Tbl

    End Function

    Public Function GetMax(ByVal FieldName As String, ByVal TableName As String) As Integer

        Call connectionopen()
        Dim CMD As New SqlCommand
        CMD.CommandText = "Select  isnull(Max(" & FieldName & "),0) From " & TableName
        CMD.Connection = con
        GetMax = CMD.ExecuteScalar + 1

    End Function

    Public Sub ComboFiller(ByVal Query As String, ByVal Combo As Object, ByVal DispFld As String, ByVal ValFld As String)
        Dim lTable As New DataTable
        Call connectionopen()
        Dim da As New SqlDataAdapter
        Dim lCmd As New SqlCommand(Query, con)
        da.SelectCommand = lCmd
        da.Fill(lTable)

        If lTable.Rows.Count = 0 Then
            Combo.DataSource = Nothing
            Combo.Items.Clear()
        Else
            Combo.DataSource = lTable
            Combo.DisplayMember = DispFld
            Combo.ValueMember = ValFld
        End If
    End Sub
    Public Function GetPrviligesRoleisAddNew(ByVal pvFormName As String, ByVal pvGroupID As Integer) As Boolean
        Dim IsAddNew = False
        DatasetFill("SELECT UserGroupPrivilegesRoles.PRID FROM UserGroupPrivilegesRoles INNER JOIN SoftwareWinForm ON UserGroupPrivilegesRoles.SWFID = SoftwareWinForm.SWFID WHERE (UserGroupPrivilegesRoles.GroupID = " & pvGroupID & ") AND (SoftwareWinForm.SwinFormName = '" & pvFormName & "')", "CheckingRights")
        For i = 0 To ds.Tables("CheckingRights").Rows.Count - 1
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 1 Then
                IsAddNew = True
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 6 Then
                IsAddNew = False
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 2 Then
                IsAddNew = True
            End If
        Next
        Return IsAddNew
    End Function

    Public Function GetPrviligesRoleisUpdate(ByVal pvFormName As String, ByVal pvGroupID As Integer) As Boolean
        Dim IsUpdate = False
        DatasetFill("SELECT UserGroupPrivilegesRoles.PRID FROM UserGroupPrivilegesRoles INNER JOIN SoftwareWinForm ON UserGroupPrivilegesRoles.SWFID = SoftwareWinForm.SWFID WHERE (UserGroupPrivilegesRoles.GroupID = " & pvGroupID & ") AND (SoftwareWinForm.SwinFormName = '" & pvFormName & "')", "CheckingRights")
        For i = 0 To ds.Tables("CheckingRights").Rows.Count - 1
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 1 Then
                IsUpdate = True
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 6 Then
                IsUpdate = False
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 3 Then
                IsUpdate = True
            End If
        Next
        Return IsUpdate
    End Function
    Public Function GetPrviligesRoleisDelete(ByVal pvFormName As String, ByVal pvGroupID As Integer) As Boolean
        Dim IsDelete = False
        DatasetFill("SELECT UserGroupPrivilegesRoles.PRID FROM UserGroupPrivilegesRoles INNER JOIN SoftwareWinForm ON UserGroupPrivilegesRoles.SWFID = SoftwareWinForm.SWFID WHERE (UserGroupPrivilegesRoles.GroupID = " & pvGroupID & ") AND (SoftwareWinForm.SwinFormName = '" & pvFormName & "')", "CheckingRights")
        For i = 0 To ds.Tables("CheckingRights").Rows.Count - 1
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 1 Then
                IsDelete = True
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 6 Then
                IsDelete = False
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 4 Then
                IsDelete = True
            End If
        Next
        Return IsDelete
    End Function
    Public Function GetPrviligesRoleisPrint(ByVal pvFormName As String, ByVal pvGroupID As Integer) As Boolean
        Dim IsPrint = False
        DatasetFill("SELECT UserGroupPrivilegesRoles.PRID FROM UserGroupPrivilegesRoles INNER JOIN SoftwareWinForm ON UserGroupPrivilegesRoles.SWFID = SoftwareWinForm.SWFID WHERE (UserGroupPrivilegesRoles.GroupID = " & pvGroupID & ") AND (SoftwareWinForm.SwinFormName = '" & pvFormName & "')", "CheckingRights")
        For i = 0 To ds.Tables("CheckingRights").Rows.Count - 1
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 1 Then
                IsPrint = True
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 6 Then
                IsPrint = False
                Exit For
            End If
            If ds.Tables("CheckingRights").Rows(i).Item(0) = 5 Then
                IsPrint = True
            End If
        Next
        Return IsPrint
    End Function
End Module
