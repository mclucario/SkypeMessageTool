Imports SKYPE4COMLib

Public Class Form1

    Dim Skype As New SKYPE4COMLib.Skype
    Dim ArrayBuffer As Array
    Dim HandleBuffer As String
    Dim NameBuffer As String
    Dim counter = 0

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.TabIndexChanged

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        If TabControl1.SelectedIndex = 0 Then

            For Each User As SKYPE4COMLib.User In Skype.Friends

                ListBox1.Items.Add(User.Handle + ", " + User.FullName)

            Next

        End If

        If TabControl1.SelectedIndex = 0 Then

            For Each Group As SKYPE4COMLib.Group In Skype.Groups

                ListBox3.Items.Add(Group.DisplayName)

            Next

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        counter = ListBox1.Items.Count - 1

        While counter > -1

            ListBox2.Items.Add(ListBox1.Items.Item(counter))
            ListBox1.Items.Remove(ListBox1.Items.Item(counter))

            counter -= 1

        End While

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ListBox1.SelectedItems.Count = 1 Then

            ListBox2.Items.Add(ListBox1.SelectedItem)
            ListBox1.Items.Remove(ListBox1.SelectedItem)

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ListBox2.SelectedItems.Count = 1 Then

            ListBox1.Items.Add(ListBox2.SelectedItem)
            ListBox2.Items.Remove(ListBox2.SelectedItem)

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        counter = ListBox2.Items.Count - 1

        While counter > -1

            ListBox1.Items.Add(ListBox2.Items.Item(counter))
            ListBox2.Items.Remove(ListBox2.Items.Item(counter))

            counter -= 1

        End While

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        SendMessageSMM()

    End Sub

    Sub SendMessageSMM()

        If ListBox2.Items.Count = 0 Then

            MsgBox("You haven't selected any contacts which should get the message.", MsgBoxStyle.Exclamation, "No contacts")

            Exit Sub

        End If

        If RichTextBox1.Text = "" Then

            MsgBox("You haven't written anything into the textbox.", MsgBoxStyle.Exclamation, "No message")

            Exit Sub

        End If

        Try

            For Each Item In ListBox2.Items

                ArrayBuffer = Item.ToString.Split(CChar(","))
                HandleBuffer = ArrayBuffer(0)
                NameBuffer = ArrayBuffer(1).ToString.Remove(0, 1)

                Skype.SendMessage(HandleBuffer, RichTextBox1.Text.Replace("%contact%", NameBuffer))

            Next

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If ListBox3.Items.Count = 0 Then

            MsgBox("You haven't selected any contacts which should get the message.", MsgBoxStyle.Exclamation, "No contacts")

            Exit Sub

        End If

        If RichTextBox2.Text = "" Then

            MsgBox("You haven't written anything into the textbox.", MsgBoxStyle.Exclamation, "No message")

            Exit Sub

        End If

        Try

            For Each Group As SKYPE4COMLib.Group In Skype.Groups



                For Each User As SKYPE4COMLib.User In Group.Users


                Next

            Next

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub

End Class
