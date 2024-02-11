
using UnityEngine;

namespace Zong.Particle
{
    public class Particle : MonoBehaviour
    {
        #region Unity Properties
        [field: SerializeField]
        private ParticleType particleType;
        #endregion
        #region Unity Methods
        private void Awake()
        {
            var main = GetComponent<ParticleSystem>().main;
            main.stopAction = ParticleSystemStopAction.Callback;
        }
        private void OnParticleSystemStopped()
        {
            if (particleType == ParticleType.Spark)
                Singleton<PoolManager>.Instance.ReturnSparkParticleToPool(gameObject);
            else
                Singleton<PoolManager>.Instance.ReturnEtheralParticleToPool(gameObject);
        }
        #endregion
    }

}
