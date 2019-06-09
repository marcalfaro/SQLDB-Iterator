Option Explicit On
Imports System.Data.SqlClient

Public Class Form1
    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        List_All_Database()
    End Sub

    Private Sub List_All_Database()
        Using con As New SqlConnection("Data Source=MARCVX;Integrated Security=True")
            con.Open()
            Using cmd As New SqlCommand("sp_databases", con)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    Using sReader As SqlDataReader = cmd.ExecuteReader
                        If sReader.HasRows Then
                            While sReader.Read
                                Debug.Print(sReader("DATABASE_NAME"))
                            End While
                        End If
                    End Using
                End With
            End Using
            con.Close()
        End Using
    End Sub
End Class
