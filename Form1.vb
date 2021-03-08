Option Explicit On
Option Strict On

'Dylan Nelson
'RCET0265 
'Spring 2021
'Math Contest
'https://github.com/dylannelson58/Math_Contest

Public Class MathContestForm

    Dim mathValidation As Integer
    Dim goodJob As Integer
    Dim totalAttempts As Integer
    Dim summaryValue As Double
    Dim firstNumber As Integer
    Dim secondNumber As Integer

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        firstnumber = CInt(RandomNumberOne(100))
        secondNumber = CInt(RandomNumberTwo(100))

        FirstNumberTextBox.Text = CStr(firstnumber)
        SecondNumberTextBox.Text = CStr(secondNumber)

    End Sub


    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        AgeNameValidation()
        MathChecker()

        Try
            If CInt(StudentAnswerTextBox.Text) = CInt(mathValidation) Then
                MsgBox($"Congratulations, the correct answer is {mathValidation}!")
                goodJob += 1
            End If

            If CInt(StudentAnswerTextBox.Text) <> CInt(mathValidation) Then
                MsgBox("That is not the correct answer" & vbNewLine &
                       $"The correct answer is {mathValidation}")
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        totalAttempts += 1

        FirstNumberTextBox.Text = CStr(RandomNumberOne(100))
        SecondNumberTextBox.Text = CStr(RandomNumberOne(100))

        'FirstNumberTextBox.Text = CStr(firstNumber)
        'SecondNumberTextBox.Text = CStr(secondNumber)

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        NameTextBox.Text = ""
        StudentAnswerTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        Try
            summaryValue = (goodJob \ totalAttempts) * 100
            MsgBox($"You got ({summaryValue})%, with {totalAttempts} attempts!")
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub


    Private Function AgeNameValidation() As Boolean
        'Dim checkForAge As Boolean
        'checkForAge = True
        Dim problemMessage As String
        Dim age711 As Integer
        Dim grade14 As Integer
        Try
            age711 = CInt(AgeTextBox.Text)
        Catch ex As Exception
            MsgBox("Enter age")
            Exit Function
        End Try

        Try
            grade14 = CInt(GradeTextBox.Text)
        Catch ex As Exception
            MsgBox("Enter grade")
            Exit Function
        End Try

        If age711 > CInt(11) Then
            problemMessage &= "Student not eligible to compete" & vbNewLine
            MsgBox("Student not eligible to compete")
        End If

        If age711 < CInt(7) Then
            problemMessage &= "Student not eligible to compete" & vbNewLine
            MsgBox("Student not eligible to compete")
        End If


        If grade14 > CInt(1) Then
            problemMessage &= "Student not eligible to compete" & vbNewLine
            MsgBox("Student not eligible to compete")
        End If

        If grade14 < CInt(4) Then
            problemMessage &= "Student not eligible to compete" & vbNewLine
            MsgBox("Student not eligible to compete")
        End If

        If NameTextBox.Text = "" Then
            problemMessage &= "Please enter your name" & vbNewLine
            MsgBox("Please enter your name")
        End If

        Return True
    End Function

    Private Function RandomNumberOne(maxNumber As Integer) As Integer
        Randomize(DateTime.Now.Millisecond)
        Return CInt(Math.Floor(Rnd() * (maxNumber)))
    End Function

    Private Function RandomNumberTwo(maxNumber As Integer) As Integer
        Randomize(DateTime.Now.Millisecond)
        Return CInt(Math.Floor(Rnd() * (maxNumber)))
    End Function

    Public Function MathChecker() As Integer

        'FirstNumberTextBox.Text = CStr(firstNumber)
        'SecondNumberTextBox.Text = CStr(secondNumber)

        If AddRadioButton.Checked Then
            mathValidation = CInt(firstNumber) + CInt(secondNumber)
        End If

        If SubtractRadioButton.Checked Then
            mathValidation = CInt(firstNumber) - CInt(secondNumber)
        End If

        If MultiplyRadioButton.Checked Then
            mathValidation = CInt(firstNumber) * CInt(secondNumber)
        End If

        If DivideRadioButton.Checked Then
            mathValidation = CInt(firstNumber) \ CInt(secondNumber)
        End If

    End Function

End Class


