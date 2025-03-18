using UnityEngine;

public class FireBallCreate : MonoBehaviour
{
    [SerializableField] int fireBallCount;
    [SerializableField] float fireBallSpeed;
    [SerializableField] float fireBallDamage;
    [SerializableField] float fireBallLifeTime;

    public void FireBallCreate()
    {
        GameObject fireBall = Instantiate(Resources.Load<GameObject>("FireBall"), transform.position, transform.rotation);
        fireBall.GetComponent<FireBall>().SetFireBall(fireBallCount, fireBallSpeed, fireBallDamage, fireBallLifeTime);
    }

}
