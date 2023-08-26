using UnityEngine;

[System.Serializable]
public class AbilityHolder : MonoBehaviour
{
    public Ability _ability;
    private StarterAssets _control;
    
    private float _cooldownTime;
    private float _activeTime;

    private enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    private AbilityState _state = AbilityState.ready;

    private void Start()
    {
        _control = new StarterAssets();
        _control.Player.Dash.performed += ctx => TryActivateAbility();
    }

    private void TryActivateAbility()
    {
        
        if (_state == AbilityState.ready)
        {
            Debug.Log("Dash Activate");
            _ability.Activate(gameObject);
            _state = AbilityState.active;
            _activeTime = _ability._activeTime;
        }
    }

    private void Update()
    {
        switch (_state)
        {
            case AbilityState.ready:
                break;
            case AbilityState.active:
                _activeTime -= Time.deltaTime;
                if (_activeTime <= 0)
                {
                    _state = AbilityState.cooldown;
                    _cooldownTime = _ability._cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                _cooldownTime -= Time.deltaTime;
                if (_cooldownTime <= 0)
                {
                    _state = AbilityState.ready;
                }
                break;
        }
    }
}