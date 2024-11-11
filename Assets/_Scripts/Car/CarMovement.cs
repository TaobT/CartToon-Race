using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BoostLevel
{
    None,
    Low,
    Medium,
    High
}

public class CarMovement : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Limits")]
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float maxReverseSpeed = 5f;

    [Header("Car Stats")]
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float reverseAcceleration = 2.5f;
    [SerializeField] private float brakeDeceleration = 10f;
    [SerializeField] private float naturalDeceleration = 5f;
    [SerializeField] private float turnSpeed = 180f;

    [Header("Drifting")]
    [SerializeField] private Transform carModel;
    [SerializeField] private float driftModelRotation = 25f;
    [SerializeField] private float driftRotation = 90f;
    [SerializeField] private TrailRenderer[] driftMarks;

    [Header("Drift Boost")]
    [SerializeField] private float driftBonusSpeedDuration = 2f;
    [SerializeField] private float lowBoostBonusSpeed = 1f;
    [SerializeField] private float driftTime_mediumBoost = 3f;
    [SerializeField] private float mediumBoostBonusSpeed = 2f;
    [SerializeField] private float driftTime_highBoost = 6f;
    [SerializeField] private float highBoostBonusSpeed = 4f;
    [SerializeField] private FX_Boost fxBoost;

    private float currentSpeed;

    private bool isAccelerating;
    private bool isBraking;
    private bool isReverse;

    private bool isDrifting;
    private bool isDriftingRight;

    private BoostLevel boostLevel;
    private bool isBoosted;
    private float currentBoostTime;
    private bool isGainingBoost;
    private float currentGainingBoostTime;

    private bool canMove;

    private void Awake()
    {
        InputManager.Initialize();
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {

        if (!canMove) return;
        if(isAccelerating)
        {
            Acelerate(acceleration);
        }

        if(isBraking)
        {
            Decelerate(brakeDeceleration);
        }

        if(isReverse)
        {
            Acelerate(-reverseAcceleration);
        }

        if(!isAccelerating && !isBraking && !isReverse)
        {
            Decelerate(naturalDeceleration);
        }

        MoveCar();
        Steering();

        GainingBoost();
    }

    private void MoveCar()
    {
        if (!canMove) return;
        float totalCurrentSpeed = currentSpeed;

        if(isBoosted)
        {
            switch(boostLevel)
            {
                case BoostLevel.Low:
                    totalCurrentSpeed += lowBoostBonusSpeed;
                    break;
                case BoostLevel.Medium:
                    totalCurrentSpeed += mediumBoostBonusSpeed;
                    break;
                case BoostLevel.High:
                    totalCurrentSpeed += highBoostBonusSpeed;
                    break;
            }

            currentBoostTime -= Time.fixedDeltaTime;
            if(currentBoostTime <= 0)
            {
                isBoosted = false;
                boostLevel = BoostLevel.None;
                fxBoost.SwitchBoostLevel(boostLevel);
            }
        }

        rb.MovePosition(transform.position + transform.forward * totalCurrentSpeed * Time.fixedDeltaTime);
    }

    private void Acelerate(float amout)
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += amout * Time.fixedDeltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
    }

    private void Decelerate(float amount)
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= amount * Time.fixedDeltaTime;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
        else if (currentSpeed < 0)
        {
            currentSpeed += amount * Time.fixedDeltaTime;
            if (currentSpeed > 0)
            {
                currentSpeed = 0;
            }
        }
    }

    private void Steering()
    {
        float speedFactor = currentSpeed / maxSpeed;
        float totalTurnSpeed = turnSpeed * InputManager.SteeringDirection;
        if (isDrifting)
        {
            totalTurnSpeed += isDriftingRight ? driftRotation : -driftRotation;
        }
        float turnAmount = totalTurnSpeed * speedFactor * Time.fixedDeltaTime;
        transform.Rotate(0, turnAmount, 0);
    }

    private void GainingBoost()
    {
        if (!isGainingBoost) return;

        currentGainingBoostTime += Time.fixedDeltaTime;

        if(currentGainingBoostTime < driftTime_mediumBoost)
        {
            boostLevel = BoostLevel.Low;
        }
        else if (currentGainingBoostTime >= driftTime_mediumBoost && currentGainingBoostTime < driftTime_highBoost)
        {
            boostLevel = BoostLevel.Medium;
        }
        else if (currentGainingBoostTime >= driftTime_highBoost)
        {
            boostLevel = BoostLevel.High;
        }

        fxBoost.SwitchBoostLevel(boostLevel);
    }

    private void CalculateBoost()
    {
        if (!isGainingBoost) return;

        isBoosted = true;
        currentBoostTime = driftBonusSpeedDuration;
        currentGainingBoostTime = 0;
    }


    private void OnEnable()
    {
        InputManager.OnAcceleratorPerformed += StartAcceleration;
        InputManager.OnAcceleratorCanceled += StopAcceleration;
        InputManager.OnReversePerformed += StartBrakingReverse;
        InputManager.OnReverseCanceled += StopBrakingReverse;
        InputManager.OnDriftPerformed += StartDrifting;
        InputManager.OnDriftCanceled += StopDrifting;
    }

    private void OnDisable()
    {
        InputManager.OnAcceleratorPerformed -= StartAcceleration;
        InputManager.OnAcceleratorCanceled -= StopAcceleration;
        InputManager.OnReversePerformed -= StartBrakingReverse;
        InputManager.OnReverseCanceled -= StopBrakingReverse;
        InputManager.OnDriftPerformed -= StartDrifting;
        InputManager.OnDriftCanceled -= StopDrifting;
    }

    private void StartAcceleration()
    {
        isAccelerating = true;
    }

    private void StopAcceleration()
    {
        isAccelerating = false;
    }

    private void StartBrakingReverse()
    {
        if (currentSpeed > 0)
        {
            isBraking = true;
            isReverse = false;
        }
        else
        {
            isReverse = true;
            isBraking = false;
        }
    }

    private void StopBrakingReverse()
    {
        isBraking = false;
        isReverse = false;
    }

    private void StartDrifting()
    {
        if (!canMove) return;

        isDrifting = true;
        isGainingBoost = true;
        isDriftingRight = InputManager.SteeringDirection > 0;
        carModel.localRotation = Quaternion.Euler(0, isDriftingRight ? driftModelRotation : -driftModelRotation, 0);
        foreach (TrailRenderer trail in driftMarks)
        {
            trail.emitting = true;
        }
    }

    private void StopDrifting()
    {
        if(!canMove) return;

        isDrifting = false;
        CalculateBoost();
        isGainingBoost = false;
        carModel.localRotation = Quaternion.Euler(0, 0, 0);
        foreach (TrailRenderer trail in driftMarks)
        {
            trail.emitting = false;
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
