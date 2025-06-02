using UnityEngine;

public class RightFlipperController : MonoBehaviour
{
    public float rPosition = -50f; // Angulo de reposo
    public float pPosition = 0f; // Angulo cuando esta presionado
    public float hStrength = 8000f; // Fuerza del motor al activar
    public float fDamper = 150f; // Fuerza del motor al volver a reposo
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

        // Configurar limites iniciales
        limits.min = rPosition;
        limits.max = pPosition;
        hingeJoint.limits = limits;
    }

    void Update()
    {
        // Detectar entrada
        if (Input.GetKeyDown(flipperKey))
        {
            isPressed = false;
        }
        else if (Input.GetKeyUp(flipperKey))
        {
            isPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (isPressed)
        {
            // Activar palanca: alta velocidad y torque maximo
            motor.motorSpeed = -1000f; // Velocidad negativa para ir hacia pressedPosition
            motor.maxMotorTorque = hStrength;
        }
        else
        {
            // Volver a reposo: velocidad positiva y torque reducido
            motor.motorSpeed = 1000f;
            motor.maxMotorTorque = fDamper;
        }

        hingeJoint.motor = motor;
    }
}