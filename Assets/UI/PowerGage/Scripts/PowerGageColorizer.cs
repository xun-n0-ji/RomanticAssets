using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PowerGaugeColorizer : MonoBehaviour
{
    [Header("参照")]
    public Image backgroundImage; // 黒背景
    public Image fillImage;       // 塗り部分
    public Outline backgroundOutline;  // 枠線（Outlineコンポーネント）

    [Header("色設定")]
    public Gradient gaugeGradient; // 青→赤→オレンジ

    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        float normalizedValue = slider.normalizedValue;
        Color c = gaugeGradient.Evaluate(normalizedValue);

        // 塗り部分
        if (fillImage != null)
            fillImage.color = c;

        // 枠線
        if (backgroundOutline != null)
            backgroundOutline.effectColor = c;

        // 背景は黒固定なら変更不要
    }
}
