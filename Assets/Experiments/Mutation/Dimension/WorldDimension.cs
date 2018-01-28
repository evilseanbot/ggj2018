using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDimension : MonoBehaviour {

	public float dimensionA;
	public float dimensionB;
	public float dimensionC;
	public bool dimensionAActive = false;
	public bool dimensionBActive = false;
	public bool dimensionCActive = false;
	private float dimensionalThreshold = 0.75f;

	public delegate void DimensionalEnterAction (Mutant.Dimension dimension);
	public static event DimensionalEnterAction OnDimensionalEnter;
	public delegate void DimensionalExitAction (Mutant.Dimension dimension);
	public static event DimensionalExitAction OnDimensionalExit;

	public void OnScrubbed() {
		if (dimensionA > dimensionalThreshold && !dimensionAActive) {
			dimensionAActive = true;
			OnDimensionalEnter (Mutant.Dimension.A);
		}

		if (dimensionA <= dimensionalThreshold && dimensionAActive) {
			dimensionAActive = false;
			OnDimensionalExit (Mutant.Dimension.A);
		}

		if (dimensionB > dimensionalThreshold && !dimensionBActive) {
			dimensionBActive = true;
			OnDimensionalEnter (Mutant.Dimension.B);
		}

		if (dimensionB <= dimensionalThreshold && dimensionBActive) {
			dimensionBActive = false;
			OnDimensionalExit (Mutant.Dimension.B);
		}

		if (dimensionC > dimensionalThreshold && !dimensionCActive) {
			dimensionCActive = true;
			OnDimensionalEnter (Mutant.Dimension.C);
		}

		if (dimensionC <= dimensionalThreshold && dimensionCActive) {
			dimensionCActive = false;
			OnDimensionalExit (Mutant.Dimension.C);
		}


	}
}
