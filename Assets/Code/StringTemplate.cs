using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringTemplate
{
    public static string ParseAndReplaceTemplate(string description, Client client, Client lover)
    {
        string result = description;
        result = result.Replace("{l}", lover.FirstName);
        result = result.Replace("{c}", client.FirstName);
        return result;
    }
}
