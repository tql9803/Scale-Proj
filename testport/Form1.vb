Imports System.Data.SqlClient
Imports System.Net.Sockets
Imports System.Text
Imports System.IO.Ports ' dung de cho dinh nghia port


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim k As Integer
        Dim user As String
        Dim total As Integer

        Label11.Text = "Hi" + " " + Form2.TextBox1.Text + " , " + "Welcome you to PSA"
        user = Form2.TextBox1.Text
        total = 0
        k = 0



    End Sub
    Private Sub DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_Port1.DataReceived
        Dim inbuff As String
        inbuff = Serial_Port1.ReadExisting() ' Receiving Value From the Serial Port
        TextBox1.Text = inbuff
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Serial_Port1.WriteLine("Hello World!")
    End Sub

    Private Sub Port_press(sender As Object, e As EventArgs) Handles btnGetSerialPorts.Click

        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames())
        If ComboBox1.Items.Count <> 0 Then

            Try
                Serial_Port1.PortName = ComboBox1.Text
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        '''''

    End Sub

    Private Sub Connect_Pressed(sender As Object, e As EventArgs) Handles ConnectBtn.Click
        If Serial_Port1.IsOpen Then
            Serial_Port1.Close()
        End If
        Try

            Serial_Port1.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class


