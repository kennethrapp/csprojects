Option Strict On
Public Structure AddressBookEntry
    Public firstName As String
    Public lastName As String
    Public address As String
    Public city As String
    Public state As String
    Public zipcode As String
    Public phoneNumber As String
    Public email As String

    Public Overrides Function ToString() As String
        Return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", firstName, lastName, address, city, state, zipcode, phoneNumber, email)
    End Function

    Public Function List() As String
        Return String.Format("{0},{1} : {2} | {3}", lastName, firstName, phoneNumber, email)
    End Function


    Public Sub Load(ByRef params As String())
        Try
            firstName = params(0)
            lastName = params(1)
            address = params(2)
            city = params(3)
            state = params(4)
            zipcode = params(5)
            phoneNumber = params(6)
            email = params(7)
        Catch ex As Exception
            MessageBox.Show("invalid parameters.")
        End Try
    End Sub
End Structure


