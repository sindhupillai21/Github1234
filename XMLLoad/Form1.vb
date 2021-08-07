Imports System.Data.SqlClient


Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ds As New DataSet

        Dim i As Integer

        Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim xmlFilePath As String = openFileDialog.FileName
            'ds As DataSet = New DataSet()
            ds.ReadXml(xmlFilePath)
            DataGridView1.DataSource = ds.Tables(0)
            'If DataGridView1.DataSource <= 0 Then

            'For i = 0 To ds.Tables(0).Rows.Count - 1

            'View1.DataSource.Rows(i).Item("Id")
            'DataGridView1.DataSource.Rows(i).Item("FullName")
            'dView1.DataSource.Rows(i).Item("Country")


            'Next
            'End If

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        Try
            con.ConnectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=sql0329;server=DIT-181536L\SQLEXPRESS"
            con.Open()
            cmd.Connection = con

            cmd = New SqlCommand("insert into customer (Id,Name,Country) values (@Id, @FullName,@Country)", con)
            'cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters("@Id").Value = row.Cells(0).Value.ToString
                    cmd.Parameters("@FullName").Value = row.Cells(1).ToString
                    cmd.Parameters("@Country").Value = row.Cells(2).ToString
                End If
            Next
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Inserted")


            'MessageBox.Show("Data Inserted succeessfully")

        Catch ex As Exception

            MessageBox.Show("Invalid" & ex.Message)
        Finally
            con.Close()
        End Try



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim ds As New DataSet

        DataGridView1.DataSource.WriteXml("C:\Ajith-DIT\MyData2.xml", XmlWriteMode.WriteSchema)

    End Sub
End Class
