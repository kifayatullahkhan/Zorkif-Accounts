Public Class FrmMain

    Private Sub JournalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalToolStripMenuItem.Click
        FrmJournal.MdiParent = Me
        FrmJournal.Show()
    End Sub
End Class