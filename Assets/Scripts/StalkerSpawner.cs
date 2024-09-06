using System.Collections;
using UnityEngine;

public class StalkerSpawner : MonoBehaviour
{
        [SerializeField] private Stalker _prefab;
        [SerializeField] private Target _target;
        
        private Coroutine _coroutine;
    
        public void Update()
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(Spawn());
        }

        public IEnumerator Spawn()
        {
            while (true)
            {
                float delay = 5f;
                var wait = new WaitForSeconds(delay);
            
                Stalker stalker = Instantiate(_prefab, transform.position, Quaternion.identity);
                stalker.Init(_target.transform);
            
                yield return wait;
            }
        }
}