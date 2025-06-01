using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float restPosition = -50f; // �ngulo de reposo
    public float pressedPosition = 0f; // �ngulo cuando est� presionado
    public float hitStrength = 8000f; // Fuerza del motor al activar
    public float flipperDamper = 150f; // Fuerza del motor al volver a reposo
    public KeyCode flipperKey; // Tecla para activar

    private new HingeJoint2D hingeJoint;
    private JointMotor2D motor;
    private JointAngleLimits2D limits;
    private bool isPressed = false;

    void Awake()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        motor = hingeJoint.motor;
        limits = hingeJoint.limits;

        // Configurar l�mites iniciales
        limits.min = restPosition;
        limits.max = pressedPosition;
        hingeJoint.limits = limits;
    }

    void Update()
    {
        // Detectar entrada
        if (Input.GetKeyDown(flipperKey))
        {
            isPressed = true;
        }
        else if (Input.GetKeyUp(flipperKey))
        {
            isPressed = false;
        }
    }

    void FixedUpdate()
    {
        if (isPressed)
        {
            // Activar palanca: alta velocidad y torque m�ximo
            motor.motorSpeed = -1000f; // Velocidad negativa para ir hacia pressedPosition
            motor.maxMotorTorque = hitStrength;
        }
        else
        {
            // Volver a reposo: velocidad positiva y torque reducido
            motor.motorSpeed = 1000f;
            motor.maxMotorTorque = flipperDamper;
        }

        hingeJoint.motor = motor;
    }
}