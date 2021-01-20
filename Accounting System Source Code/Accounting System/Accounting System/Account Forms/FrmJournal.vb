Imports System.Data.SqlClient 
Public Class FrmJournal
    Private Sub FrmJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainModule.connectionopen()
        DGJournalFill()
        GroupBox1.Enabled = False
        ComboFiller("Select ACFRID,ACFRule from AccountFixRules", CmbAccountFixRule, "ACFRule", "ACFRID")
        ComboFiller("Select ACID,ACHead from AccountHead", CmbAccountHead, "ACHead", "ACID")
        ComboFiller("Select ETID,ETypes from EntryType", CmbEntryType, "ETypes", "ETID")
    End Sub
    Private Sub TextBoxesClear()
        TxtAmount.Text = ""
        TxtDescription.Text = ""
        TxtRef.Text = ""
        CmbAccountFixRule.SelectedIndex = 0
        CmbAccountHead.SelectedIndex = 0
        CmbEntryType.SelectedIndex = 0
    End Sub
    Private Sub DGJournalFill()
        Try
            DatasetFill("Select JID,SerialNo,DateTime,Description,Ref,Dr,Cr from Journal", "Journal")
            DGJournal.DataSource = ds.Tables("Journal")
            DGJournal.Columns(0).HeaderText = "Journal ID"
            DGJournal.Columns(0).Visible = False
            DGJournal.Columns(1).HeaderText = "Serial No"
            DGJournal.Columns(1).Width = 80
            DGJournal.Columns(2).HeaderText = "Date"
            DGJournal.Columns(2).Width = 60
            DGJournal.Columns(3).HeaderText = "Description"
            DGJournal.Columns(3).Width = 150
            DGJournal.Columns(4).HeaderText = "Ref"
            DGJournal.Columns(4).Width = 80
            DGJournal.Columns(5).HeaderText = "Dr"
            DGJournal.Columns(5).Width = 80
            DGJournal.Columns(6).HeaderText = "Cr"
            DGJournal.Columns(6).Width = 80
            'DatasetFill("Select JID,SerialNo,DateTime,Description,Ref,Dr,Cr from Journal", "Journal")
            'DGJournal.DataSource = ds.Tables("Journal")
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub BtnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddNew.Click
        GroupBox1.Enabled = True
        TextBoxesClear()
        If TxtAmount.Text = "" Then
            StatusStrip1.Items(0).Text = "Enter Amount"
            Exit Sub
        ElseIf TxtDescription.Text = "" Then
            StatusStrip1.Items(0).Text = "Enter Description"
            Exit Sub
        End If
        TxtAmount.Focus()
        Try

        Catch ex As Exception

        End Try
        ' MsgBox("Hello Tayaif")
    End Sub
End Class