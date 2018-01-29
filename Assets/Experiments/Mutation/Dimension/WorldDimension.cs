using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldDimension : MonoBehaviour {

	public class DimensionData {
		public float value = 0;
		public bool active = false;
	}

	public Dictionary<Mutant.Dimension, DimensionData> dimensionData;

	private float dimensionalThreshold = 0.75f;

	public delegate void DimensionalEnterAction (Mutant.Dimension dimension);
	public static event DimensionalEnterAction OnDimensionalEnter;
	public delegate void DimensionalExitAction (Mutant.Dimension dimension);
	public static event DimensionalExitAction OnDimensionalExit;

	public void Start() {
		dimensionData = new Dictionary<Mutant.Dimension, DimensionData> ();
		foreach (Mutant.Dimension dimension in Enum.GetValues(typeof(Mutant.Dimension))) {
			if (dimension != Mutant.Dimension.none) {
				dimensionData.Add (dimension, new DimensionData ());
			}
		}

	}

	public void OnScrubbed() {
		foreach (Mutant.Dimension dimension in Enum.GetValues(typeof(Mutant.Dimension))) {
			if (dimension != Mutant.Dimension.none) {
				if (dimensionData [dimension].value > dimensionalThreshold && !dimensionData [dimension].active) {
					dimensionData[dimension].active = true;
					OnDimensionalEnter (dimension);
				}

				if (dimensionData[dimension].value <= dimensionalThreshold && dimensionData[dimension].active) {
					dimensionData[dimension].active = false;
					OnDimensionalExit (dimension);
				}

			}
		}
	}
}
