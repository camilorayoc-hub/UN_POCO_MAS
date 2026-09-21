// Assets/Scripts/IAPManager.cs
using System.Collections;
using UnityEngine;

// Ajusta namespaces/clases según el plugin que instales
// Este es un esqueleto conceptual: reemplaza PlayBillingClient por la API real del plugin.
public class IAPManager : MonoBehaviour
{
    public static IAPManager Instance;
    public string productRemoveAds = "remove_ads";
    public string productCoins100 = "coins_100";
    public string productPremiumMonthly = "premium_monthly";

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    void Start()
    {
        InitializeBilling();
    }

    void InitializeBilling()
    {
        // Inicializa el cliente de facturación del plugin que instales
        Debug.Log("Inicializando facturación (reemplaza con la API del plugin)");
    }

    public void BuyProduct(string productId)
    {
        Debug.Log($"Solicitando compra: {productId}");
        // Lógica de compra: lanzar flujo de compra del plugin
        // Al completar, enviar purchaseToken al servidor para validación
    }

    IEnumerator ValidatePurchaseOnServer(string purchaseToken, string sku)
    {
        var form = new WWWForm();
        form.AddField("purchaseToken", purchaseToken);
        form.AddField("sku", sku);
        form.AddField("packageName", Application.identifier);

        using (var www = UnityEngine.Networking.UnityWebRequest.Post("https://tu-servidor/validate", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
                Debug.Log("Validación servidor OK: " + www.downloadHandler.text);
            else
                Debug.LogWarning("Validación servidor fallida: " + www.error);
        }
    }
}
