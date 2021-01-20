Imports System.Data.SqlClient
Module MdPublicVariables
    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public VUserID As New Integer
    Public VUserName As String
    Public VGroupID As Integer
    Public vServerName As String
    Public VGroupName As String
    Public isAdmininistrator As Boolean
    Public VVersion As String
    Public Modules As String
    Public VPrisonID As String
    Public FormID As String
    Public LBLPrisoner As String
    Public NumN As String
End Module
