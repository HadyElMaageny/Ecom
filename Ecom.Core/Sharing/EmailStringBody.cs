namespace Ecom.Core.Sharing;

public class EmailStringBody
{
    public static string Send(string email, string token, string component, string message)
    {
        string encodedToken = Uri.EscapeDataString(token);

        return $@"
<html>
<head>
    <style>
        .button {{
            border: none;
            border-radius: 10px;
            padding: 15px 30px;
            color: #fff;
            display: inline-block;
            background: linear-gradient(45deg, #ff7e5f, #feb47b);
            cursor: pointer;
            text-decoration: none;
            font-size: 16px;
            font-weight: bold;
            font-family: Arial, sans-serif;
            transition: all 0.3s ease;
        }}

        .button:hover {{
            background: linear-gradient(45deg, #ff9068, #ffb88c);
        }}

        h1 {{
            font-family: Arial, sans-serif;
        }}

        body {{
            font-family: Arial, sans-serif;
            padding: 20px;
        }}
    </style>
</head>

<body>
    <h1>{message}</h1>
    <hr><br>

    <a class=""button"" href=""http://localhost:4200/Account/{component}?email={email}&code={encodedToken}"">
        {message}
    </a>

    <br><br>
    <p>If you did not request this action, please ignore this email.</p>
</body>

</html>
";
    }
}