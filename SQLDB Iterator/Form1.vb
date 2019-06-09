Option Explicit On
Imports System.Data.SqlClient

Public Class Form1
    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        List_All_Database()
    End Sub

    Private Sub List_All_Database()
        'There are 3 queries to do this:
        '1. EXEC sp_databases
        '2. SELECT name FROM master.sys.databases
        '3. SELECT * FROM sys.databases d WHERE d.database_id > 4


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
