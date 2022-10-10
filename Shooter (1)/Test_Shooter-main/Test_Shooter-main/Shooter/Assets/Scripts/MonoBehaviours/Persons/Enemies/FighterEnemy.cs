using Vector3 = UnityEngine.Vector3;

namespace Assets.Scripts.MonoBehaviours.Persons.Enemies
{
    public class FighterEnemy : Enemy
    {
        private const float Distance = 0.8f;

        private bool _isRunning;

        private void Update()
        {
            if (_isRunning)
            {
                CheckDestination();
            }
        }

        private protected override void Activate()
        {
            PersonAnimator.SetTrigger(Run);
            Agent.SetDestination(PlayerPosition);
            _isRunning = true;
        }
        
        private void CheckDestination()
        {
            transform.LookAt(PlayerPosition);
            if (Vector3.Distance(Agent.transform.position, Agent.destination) < Distance)
            {
                Agent.isStopped = true;
                _isRunning = false;
                AttackPlayer();
            }
        }

        private void AttackPlayer()
        {
            PersonAnimator.SetTrigger(Attack);
        }
    }
}