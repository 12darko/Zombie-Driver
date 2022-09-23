using System;
using System.Collections;
using System.Collections.Generic;
using EMA.Scripts.PatternClasses;
using UnityEngine;

public class CarComp : MonoSingleton<CarComp>
{
    [SerializeField] private float carTotalHealth;
    [SerializeField] private float carCurrentHealth;
    [SerializeField] private float totalFuelStatus;
    [SerializeField] private float currentFuelStatus;
    [SerializeField] private float fuelBurnRate;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private float breakeAcceleration = 50.0f;
    [SerializeField] private int carBackCurrentGold;
    [SerializeField] private int carBackTotalGold;
    [SerializeField] private float turnSensivity;
    [SerializeField] private bool gameFinish;
   

    [SerializeField] private Transform collectedCoins;
    [SerializeField] private Transform carTransform;
    [SerializeField] private Transform carRespawnTransform;
    
    [SerializeField] private Rigidbody carRb;
    [SerializeField] private GameObject particleEffect;
    
    [SerializeField] private Transform[] itemHolderTransform;
    
    [SerializeField] private GameObject coinPlace;
    [SerializeField] private GameObject nitroEffect;
    [SerializeField] private GameObject windEffect;
    [SerializeField] private GameObject confettiEffect;
    
    [SerializeField] private Vector3 carCurrentSavedTransform;
    [SerializeField] private Vector3 carCurrentSavedRotation;
    [SerializeField] private BoxCollider[] carFallCollider;
    
    public float CarTotalHealth
    {
        get => carTotalHealth;
        set => carTotalHealth = value;
    }

    public float CarCurrentHealth
    {
        get => carCurrentHealth;
        set => carCurrentHealth = value;
    }

    public float TotalFuelStatus
    {
        get => totalFuelStatus;
        set => totalFuelStatus = value;
    }

    public float CurrentFuelStatus
    {
        get => currentFuelStatus;
        set => currentFuelStatus = value;
    }

    public float FuelBurnRate
    {
        get => fuelBurnRate;
        set => fuelBurnRate = value;
    }

    public float MaxAcceleration
    {
        get => maxAcceleration;
        set => maxAcceleration = value;
    }

    public float BreakeAcceleration
    {
        get => breakeAcceleration;
        set => breakeAcceleration = value;
    }

    public int CarBackCurrentGold
    {
        get => carBackCurrentGold;
        set => carBackCurrentGold = value;
    }

    public int CarBackTotalGold
    {
        get => carBackTotalGold;
        set => carBackTotalGold = value;
    }

    public Transform CollectedCoins
    {
        get => collectedCoins;
        set => collectedCoins = value;
    }
    public Transform CarTransform => carTransform;

    public Rigidbody CarRb
    {
        get => carRb;
        set => carRb = value;
    }

    public GameObject ParticleEffect
    {
        get => particleEffect;
        set => particleEffect = value;
    }

    public GameObject WindEffect
    {
        get => windEffect;
        set => windEffect = value;
    }

    public Transform[] ItemHolderTransform
    {
        get => itemHolderTransform;
        set => itemHolderTransform = value;
    }

    public GameObject NitroEffect
    {
        get => nitroEffect;
        set => nitroEffect = value;
    }

    public Vector3 CarCurrentSavedTransform
    {
        get => carCurrentSavedTransform;
        set => carCurrentSavedTransform = value;
    }

    public Transform CarRespawnTransform
    {
        get => carRespawnTransform;
        set => carRespawnTransform = value;
    }

    public Vector3 CarCurrentSavedRotation
    {
        get => carCurrentSavedRotation;
        set => carCurrentSavedRotation = value;
    }

    public BoxCollider[] CarFallCollider
    {
        get => carFallCollider;
        set => carFallCollider = value;
    }

    public bool GameFinish
    {
        get => gameFinish;
        set => gameFinish = value;
    }

    public GameObject ConfettiEffect
    {
        get => confettiEffect;
        set => confettiEffect = value;
    }

    public float TurnSensivity
    {
        get => turnSensivity;
        set => turnSensivity = value;
    }

    public GameObject CoinPlace
    {
        get => coinPlace;
        set => coinPlace = value;
    }
}