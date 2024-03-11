using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class New_FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float fireSpeed = 20;
    public float timeBetweenPresses = 0.5f; // Adjust this value as needed
    public float bulletForce = 20f;

    public enum FiringMode
    {
        SingleShot,
        BurstOfThree,
        ContinuousFire
    }

    public FiringMode firingMode = FiringMode.SingleShot;

    private Coroutine continuousFireCoroutine;
    private float lastPressTime = 0;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    void Update()
    {
        // You can add any additional logic here if needed.
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if (Time.time - lastPressTime < timeBetweenPresses)
        {
            return; // Ignore rapid presses
        }

        lastPressTime = Time.time;

        switch (firingMode)
        {
            case FiringMode.SingleShot:
                FireSingleShot();
                break;
            case FiringMode.BurstOfThree:
                StartCoroutine(FireBurstOfThree());
                break;
            case FiringMode.ContinuousFire:
                if (continuousFireCoroutine == null)
                {
                    continuousFireCoroutine = StartCoroutine(FireContinuously());
                }
                break;
        }
    }

    private void FireSingleShot()
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnpoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * fireSpeed;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(spawnpoint.forward * bulletForce, ForceMode.Impulse);
        Destroy(spawnedBullet, 5);
    }

    private IEnumerator FireBurstOfThree()
    {
        for (int i = 0; i < 3; i++)
        {
            FireSingleShot();
            yield return new WaitForSeconds(0.1f); // Adjust the delay between shots if needed
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            FireSingleShot();
            yield return new WaitForSeconds(0.1f); // Adjust the delay between shots if needed
        }
    }
}
