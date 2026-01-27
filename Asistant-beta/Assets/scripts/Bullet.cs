using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        speed += 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            other.GetComponent<move>().ChangeHealth(-20);
        }
        if (other.CompareTag("barrel"))
        {
            other.GetComponent<bar>().babaxa();
        }
        Destroy(gameObject);
    }
}