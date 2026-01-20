using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float gravity = 50;
    [SerializeField] float jumpForce = 30;
    Vector3 direction;

    void Update()
    {
        // moveHorizontal будет принимать значение -1 если нажата кнопка A, 1 если нажата D, 0 если эти кнопки не нажаты
        float moveHorizontal = Input.GetAxis("Horizontal");
        // moveVertical будет принимать значение -1 если нажата кнопка S, 1 если нажата W, 0 если эти кнопки не нажаты
        float moveVertical = Input.GetAxis("Vertical");
        if (controller.isGrounded) //провер€ем что мы не на земле (тема условий будет дальше)
        {
            //–едактируем переменную направлени€, использу€ moveHorizontal и moveVertical
            //ћы двигаемс€ по координатам x и z, координата y дл€ прыжков.
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            //ƒополнительно умножа€ его на скорость передвижени€ (преобразу€ локальные координаты к глобальным)
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKey(KeyCode.Space)) //ѕровер€ем что нажали пробел дл€ прыжка
            {
                direction.y = jumpForce;
            }
        }
        //Ётой строчкой мы осуществл€ем изменение положени€ игрока на основе вектора direction
        //Time.deltaTime это количество секунд которое прошло с последнего кадра, дл€ синхронизации по времени
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - 5;
        }
    }
}