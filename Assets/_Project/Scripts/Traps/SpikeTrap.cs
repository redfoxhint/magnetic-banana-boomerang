﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagneticBananaBoomerang.Characters;

public class SpikeTrap : Trap
{
	// Inspector Fields
	[Tooltip("Object which holds the spikes graphics.")]
	[SerializeField] private GameObject spikeSprites;
	[Tooltip("The amount of damage the spikes will deal.")]
	[SerializeField] private float spikeDamageAmount;

	public override void Activate()
	{
		InitializeTimer();
		spikeSprites.SetActive(true);
		ApplyDamage();
	}

	public override void Deactivate()
	{
		active = false;
		spikeSprites.SetActive(false);
	}

	private void ApplyDamage()
	{
		List<GameObject> otherObjects = DetectObjectsWithinRadius(transform, range);

		if (otherObjects.Count > 0)
		{
			foreach (GameObject otherObject in otherObjects)
			{
				Vector2 dir = otherObject.transform.position - transform.position;
				IDamageable damageable = otherObject.GetComponent<IDamageable>();

				if (damageable != null)
				{
					damageable.TakeDamage(spikeDamageAmount, dir);
				}
			}
		}
	}
}