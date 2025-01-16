using UnityEngine;
using UnityEngine.UI;

public class RevenueManager : MonoBehaviour
{
    public float totalRevenue = 0;    // Total pendapatan sepanjang waktu
    public float dailyRevenue = 0;   // Pendapatan harian
    public float totalRevenue2;
    public Text totalRevenueText;    // UI untuk total pendapatan
    public Text dailyRevenueText;    // UI untuk pendapatan harian
    public Text totalRevenueText2;    // UI untuk total pendapatan

    public void AddRevenue(float amount)
    {
        dailyRevenue += amount;       // Tambahkan ke pendapatan harian
        totalRevenue += amount;       // Tambahkan ke total pendapatan
        UpdateUI();
    }

    public void ResetDailyRevenue()
    {
        dailyRevenue = 0;             // Reset pendapatan harian
        UpdateUI();
    }

    void UpdateUI()
    {
        totalRevenue2 = totalRevenue;
        // Konversi angka menjadi string tanpa tambahan label
        totalRevenueText.text = totalRevenue.ToString("F2");
        dailyRevenueText.text = dailyRevenue.ToString("F2");
        totalRevenueText2.text = totalRevenue.ToString("F2");
    }
}
