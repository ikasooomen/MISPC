using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGauge : MonoBehaviour
{
    [SerializeField]
    private Image GreenGauge;
    [SerializeField]
    private Image RedGauge;

    private Player player;
    private Tween redGaugeTween;

    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        var valueFrom = player.life / player.maxLife;
        var valueTo = (player.life - reducationValue) / player.maxLife;

        // —ÎƒQ[ƒWŒ¸­
        GreenGauge.fillAmount = valueTo;

        if (redGaugeTween != null)
        {
            redGaugeTween.Kill();
        }

        // ÔƒQ[ƒWŒ¸­
        redGaugeTween = DOTween.To(
            () => valueFrom,
            x => {
                RedGauge.fillAmount = x;
            },
            valueTo,
            time
        );
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}