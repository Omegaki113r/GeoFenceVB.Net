Imports System.IO
Imports System.Net
Imports Microsoft.Owin
Imports Owin
Imports Newtonsoft.Json.Linq.JObject
Imports Newtonsoft.Json.Linq.JArray

<Assembly: OwinStartupAttribute(GetType(Startup))>

Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        ConfigureAuth(app)


        Dim url As String = "https://api-1.test.logitrail.com/2015-01-01/yesbox/shipment/MH12345678"
        Dim test As String = "/2015-01-01/yesbox/shipment/MH12345678"
        Dim myReq As WebRequest = WebRequest.Create(url)
        myReq.Method = "GET"
        myReq.ContentType = "application/json"
        Dim username As String = "X-YESBOX"
        Dim password As String = "zaDBMcBCHgkrZ5Qv95msQ2YjZ5rH9R6ex"
        Dim usernamePassword As String = (username + ":" + password)
        'Dim mycache As CredentialCache = New CredentialCache
        '  mycache.Add(New Uri(url & test), "Basic", New NetworkCredential(username, password))
        '  myReq.Credentials = mycache
        myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(usernamePassword)))
        Dim wr As WebResponse = myReq.GetResponse
        Dim receiveStream As Stream = wr.GetResponseStream()
        Dim reader As StreamReader = New StreamReader(receiveStream, True)
        Dim content As String = reader.ReadToEnd
        ''MsgBox(content)
        ''Console.WriteLine(content)
        ''Console.ReadLine()

        Dim thisToken As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(content)
        Dim id As Newtonsoft.Json.Linq.JToken = thisToken.Item("id")
        Dim trackingCode As Newtonsoft.Json.Linq.JToken = thisToken.Item("tracking_code")
        Dim carrierTrackingCode As Newtonsoft.Json.Linq.JToken = thisToken.Item("carrier_tracking_code")
        Dim customer As Newtonsoft.Json.Linq.JToken = thisToken.Item("customer")
        Dim firstName As Newtonsoft.Json.Linq.JToken = customer.Item("firstname")
        Dim lastName As Newtonsoft.Json.Linq.JToken = customer.Item("lastname")
        Dim email As Newtonsoft.Json.Linq.JToken = customer.Item("email")
        Dim phone As Newtonsoft.Json.Linq.JToken = customer.Item("phone")
        Dim address As Newtonsoft.Json.Linq.JToken = customer.Item("address")
        Dim postalCode As Newtonsoft.Json.Linq.JToken = customer.Item("postal_code")
        Dim city As Newtonsoft.Json.Linq.JToken = customer.Item("city")
        Dim country As Newtonsoft.Json.Linq.JToken = customer.Item("country")
        Dim status As Newtonsoft.Json.Linq.JToken = thisToken.Item("status")
        Dim carrier As Newtonsoft.Json.Linq.JToken = thisToken.Item("carrier")
        Dim pickupPoint As Newtonsoft.Json.Linq.JToken = thisToken.Item("pickup_point")
        Dim pickupPointID As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("id")
        Dim pickupName As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("name")
        Dim pickupAddress As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("address")
        Dim pickupPostalCode As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("postalcode")
        Dim pickupCity As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("city")
        Dim pickupCountry As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("country")
        Dim pickupCoordinates As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("coordinates")
        Dim lattitude As Newtonsoft.Json.Linq.JToken = pickupCoordinates.Item(0)
        Dim longitude As Newtonsoft.Json.Linq.JToken = pickupCoordinates.Item(1)
        Dim pickupBranch As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("branch")
        Dim pickupLocationInfo As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("location_info")
        Dim pickupType As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("type")
        Dim carrierInfo As Newtonsoft.Json.Linq.JToken = pickupPoint.Item("carrier_info")
        Dim carrierInfoEle As Newtonsoft.Json.Linq.JToken = carrierInfo.Item(carrierInfo.ToString())
        Dim idCarrierInfo As Newtonsoft.Json.Linq.JToken = carrierInfoEle.Item("id")
        Dim weight As Newtonsoft.Json.Linq.JToken = thisToken.Item("weight")
        Dim volume As Newtonsoft.Json.Linq.JToken = thisToken.Item("volume_cm3")
        Debug.WriteLine(lattitude.ToString())
        MsgBox(pickupName.ToString())


    End Sub
End Class
