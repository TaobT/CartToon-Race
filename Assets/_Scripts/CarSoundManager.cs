using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundManager : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip engineSound;  // Sonido del motor
    public AudioClip driftSound;   // Sonido de derrape
    public AudioClip collisionSound; // Sonido de colisión
    public AudioClip brakeSound;   // Sonido de frenado
    public AudioClip boostSound;   // Sonido de impulso

    [Header("Engine Settings")]
    public float minPitch = 0.8f;  // Tono mínimo del motor
    public float maxPitch = 2.0f;  // Tono máximo del motor
    public float maxSpeed = 10f;   // Velocidad máxima para el cálculo de tono

    private AudioSource engineSource;
    private AudioSource oneShotSource;  // Fuente secundaria para sonidos no persistentes
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Configurar las fuentes de audio
        engineSource = gameObject.AddComponent<AudioSource>();
        engineSource.clip = engineSound;
        engineSource.loop = true;
        engineSource.playOnAwake = true;
        engineSource.volume = 0.5f; // Volumen del motor

        oneShotSource = gameObject.AddComponent<AudioSource>();
        oneShotSource.loop = false;
        oneShotSource.playOnAwake = false;

        engineSource.Play();
    }

    private void FixedUpdate()
    {
        UpdateEngineSound();
    }

    /// <summary>
    /// Actualiza el sonido del motor según la velocidad.
    /// </summary>
    private void UpdateEngineSound()
    {
        float speed = rb.velocity.magnitude;
        float pitch = Mathf.Lerp(minPitch, maxPitch, speed / maxSpeed);
        engineSource.pitch = pitch;
    }

    /// <summary>
    /// Reproduce el sonido de derrape.
    /// </summary>
    public void PlayDriftSound()
    {
        if (driftSound != null && !oneShotSource.isPlaying)
        {
            oneShotSource.clip = driftSound;
            oneShotSource.loop = true;
            oneShotSource.Play();
        }
    }

    /// <summary>
    /// Detiene el sonido de derrape.
    /// </summary>
    public void StopDriftSound()
    {
        if (oneShotSource.isPlaying && oneShotSource.clip == driftSound)
        {
            oneShotSource.Stop();
        }
    }

    /// <summary>
    /// Reproduce el sonido de colisión.
    /// </summary>
    public void PlayCollisionSound(Vector3 position)
    {
        if (collisionSound != null)
        {
            AudioSource.PlayClipAtPoint(collisionSound, position);
        }
    }

    /// <summary>
    /// Reproduce el sonido de frenado.
    /// </summary>
    public void PlayBrakeSound()
    {
        if (brakeSound != null)
        {
            AudioSource.PlayClipAtPoint(brakeSound, transform.position);
        }
    }

    /// <summary>
    /// Reproduce el sonido de impulso.
    /// </summary>
    public void PlayBoostSound()
    {
        if (boostSound != null)
        {
            oneShotSource.PlayOneShot(boostSound);
        }
    }
}
