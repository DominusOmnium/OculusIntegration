using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTesting : MonoBehaviour
{
    [SerializeField]
    ParticleSystem primaryPressParticle;
    [SerializeField]
    ParticleSystem secondaryPressParticle;
    [SerializeField]
    ParticleSystem axisPressParticle;
    [SerializeField]
    ParticleSystem triggerPressParticle;
    [SerializeField]
    ParticleSystem gripPressParticle;
    [SerializeField]
    GameObject primaryHintParticle;
    [SerializeField]
    GameObject secondaryHintParticle;
    [SerializeField]
    GameObject axisHintParticle;

    InputWatcher inputWatcher;
    void Awake()
    {
        inputWatcher = FindObjectOfType<InputWatcher>();
    }

    private void OnEnable()
    {
        inputWatcher.leftPrimaryButtonPress.AddListener(a => { primaryPressParticle.Play(); secondaryHintParticle.SetActive(true); primaryHintParticle.SetActive(false); });
        inputWatcher.leftSecondaryButtonPress.AddListener(a => { secondaryPressParticle.Play(); axisHintParticle.SetActive(true); secondaryHintParticle.SetActive(false); });
        inputWatcher.leftAxisPress.AddListener(a => { axisPressParticle.Play(); axisHintParticle.SetActive(false); });
        inputWatcher.leftTriggerButtonPress.AddListener(a => { if (a > 0.3f && !triggerPressParticle.isEmitting) triggerPressParticle.Play(); });
        inputWatcher.leftGripButtonPress.AddListener(a => { if (a > 0.3f && !gripPressParticle.isEmitting) gripPressParticle.Play(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
