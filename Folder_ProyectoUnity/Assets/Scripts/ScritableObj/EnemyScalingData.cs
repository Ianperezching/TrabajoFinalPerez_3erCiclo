using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyScalingData", menuName = "ScriptableObjects/EnemyScalingData", order = 2)]
public class EnemyScalingData : ScriptableObject
{
    public AnimationCurve healthCurve;
    public AnimationCurve attackCurve;
    public AnimationCurve defenseCurve;
    public AnimationCurve speedCurve;

    // Devuelve el valor escalado según el piso
    public int GetScaledValue(AnimationCurve curve, int baseValue, int floor)
    {
        return Mathf.RoundToInt(baseValue * curve.Evaluate(floor));
    }
}
