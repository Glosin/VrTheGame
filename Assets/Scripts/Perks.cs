using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Perks : MonoBehaviour
{
    public Player player;
    public TMP_Text perkText;
    public string perkNameText;
    public int perkCost;
    private XRGrabInteractable _grabInteractable;
    private ScoreController _scoreController;
    
    private void Start()
    {
        _scoreController = FindAnyObjectByType<ScoreController>();
        _grabInteractable = GetComponent<XRGrabInteractable>();
        perkText.text = $"{perkNameText}\n{perkCost}";
        _grabInteractable.enabled = false;
        if (!_grabInteractable) return;
        _grabInteractable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs arg0)
    {
        _scoreController.SubtractPoints(perkCost);
        Perk();
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_grabInteractable) _grabInteractable.enabled = _scoreController.score >= perkCost;
        
        if (!player) return;
        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 4f)
        {
            perkText.gameObject.SetActive(true);
            var directionToPlayer = perkText.transform.position - player.transform.position;
            perkText.transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
        else
        {
            perkText.gameObject.SetActive(false);
        }
    }

    protected virtual void Perk() {}
}
