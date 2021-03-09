Option Explicit On
Option Strict On

'Dylan Nelson
'RCET0265 
'Spring 2021
'Math Contest
'https://github.com/dylannelson58/Math_Contest

Public Class MathContestForm

    'sets global variables accross all functions and subs
    Dim mathValidation As Integer
    Dim goodJob As Integer
    Dim totalAttempts As Integer
    Dim firstNumber As Integer
    Dim secondNumber As Integer

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'upon loading the form random numbers are generated in the first and second number text boxes so the student can immediately start answering problems
        firstNumber = CInt(RandomNumberOne(100))
        secondNumber = CInt(RandomNumberTwo(100))

        FirstNumberTextBox.Text = CStr(firstnumber)
        SecondNumberTextBox.Text = CStr(secondNumber)

    End Sub


    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        'calls forth the functions used when submitting check each individual function for notes on specifics
        AgeNameValidation()
        MathChecker()
        CorrectOrNot()

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

        'resets all relevent variables 
        NameTextBox.Text = ""
        StudentAnswerTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        mathValidation = 0
        totalAttempts = 0
        goodJob = 0

    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click

        'if the student has not answered at all tells them to do at least one problem
        If totalAttempts = 0 Then
            MsgBox("You must try at least one time!")
            Exit Sub
        End If

        'tallies up the correct answers and total attempts
        Try
            MsgBox($"{NameTextBox.Text} got {goodJob} right, with {totalAttempts} attempts!")
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        'closes the program when exit button is clicked
        Me.Close()
    End Sub


    Private Function AgeNameValidation() As Boolean

        Dim problemMessage As String
        Dim age711 As Integer
        Dim grade14 As Integer

        'catches the user if they do not put in a value for age
        Try
            age711 = CInt(AgeTextBox.Text)
        Catch ex As Exception
            MsgBox("Enter age")
            Exit Function
        End Try

        'catches the user if they do not put in a value for grade
        Try
            grade14 = CInt(GradeTextBox.Text)
        Catch ex As Exception
            MsgBox("Enter grade")
            Exit Function
        End Try

        'sets the age range to 7-11
        If age711 > CInt(11) Then
            problemMessage &= "Student not eligible to compete, too old." & vbNewLine
        ElseIf age711 < CInt(7) Then
            problemMessage &= "Student not eligible to compete, too young." & vbNewLine
        End If

        'sets the grade range to 1-4
        If grade14 < CInt(1) Then
            problemMessage &= "Student not eligible to compete, too low of grade." & vbNewLine
        ElseIf grade14 > CInt(4) Then
            problemMessage &= "Student not eligible to compete, too high of grade." & vbNewLine
        End If

        'when name field is left blank tells the student to enter their name
        If NameTextBox.Text = "" Then
            problemMessage &= "Please enter your name" & vbNewLine
        End If

        'if there are no issues then a msg box does not appear, while any problems are concatenated into a single msg box
        If problemMessage = "" Then
        ElseIf problemMessage <> "" Then
            MsgBox(problemMessage)
        End If


        Return True
    End Function

    'both of these functions assign a random number down to the millisecond of the clock
    Private Function RandomNumberOne(maxNumber As Integer) As Integer
        Randomize(DateTime.Now.Millisecond)
        Return CInt(Math.Floor(Rnd() * (maxNumber)))
    End Function

    Private Function RandomNumberTwo(maxNumber As Integer) As Integer
        Randomize(DateTime.Now.Millisecond)
        Return CInt(Math.Floor(Rnd() * (maxNumber)))
    End Function

    Public Function MathChecker() As Integer

        're-assigns the variables for first and second number so they do not retain their old values
        firstNumber = CInt(FirstNumberTextBox.Text)
        secondNumber = CInt(SecondNumberTextBox.Text)

        'based on which radio button is selected it will perform that desired calculation and apply it to mathValidation variable
        If AddRadioButton.Checked Then
            mathValidation = CInt(firstNumber) + CInt(secondNumber)
        ElseIf SubtractRadioButton.Checked Then
            mathValidation = CInt(firstNumber) - CInt(secondNumber)
        ElseIf MultiplyRadioButton.Checked Then
            mathValidation = CInt(firstNumber) * CInt(secondNumber)
        ElseIf DivideRadioButton.Checked Then
            mathValidation = CInt(firstNumber) \ CInt(secondNumber)
        End If

    End Function

    Public Function CorrectOrNot() As Integer

        'Try
        '    mathValidation = CInt(StudentAnswerTextBox.Text)
        'Catch ex As Exception
        '    MsgBox("Numbers only for answers")
        '    Exit Function
        'End Try

        Try
            'when the student is correct they are informed and a value is assigned for giving a score at the end.
            If CInt(StudentAnswerTextBox.Text) = CInt(mathValidation) Then
                MsgBox($"Congratulations, the correct answer is {mathValidation}!")
                goodJob += 1
            End If

            'when student answer is wrong the correct answer is shown and they are informed that they are wrong.
            If CInt(StudentAnswerTextBox.Text) <> CInt(mathValidation) Then
                MsgBox("That is not the correct answer;" & vbNewLine &
                       $"The correct answer is {mathValidation}.")

            End If
        Catch ex As Exception
            Exit Function
        End Try

        'counts the total amount of times the student has submitted for the score.
        totalAttempts += 1

        'Re-randomizes the numbers to be used in a seperate submit case.
        FirstNumberTextBox.Text = CStr(RandomNumberOne(100))
        SecondNumberTextBox.Text = CStr(RandomNumberOne(100))

    End Function

End Class


