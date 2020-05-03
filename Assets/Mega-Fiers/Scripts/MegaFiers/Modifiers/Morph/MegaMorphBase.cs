using UnityEngine;
using System.Collections.Generic;

public class MegaMorphBase : MegaModifier
{
	public List<MegaMorphChan> chanBank = new List<MegaMorphChan>();
	public MegaMorphAnimType animtype = MegaMorphAnimType.Bezier;

	public override void PostCopy(MegaModifier src)
	{
		MegaMorphBase mor = (MegaMorphBase)src;

		chanBank = new List<MegaMorphChan>();

		for ( int c = 0; c < mor.chanBank.Count; c++ )
		{
			MegaMorphChan chan = new MegaMorphChan();

			MegaMorphChan.Copy(mor.chanBank[c], chan);
			chanBank.Add(chan);
		}
	}

	public string[] GetChannelNames()
	{
		string[] names = new string[chanBank.Count];

		for ( int i = 0; i < chanBank.Count; i++ )
			names[i] = chanBank[i].mName;

		return names;
	}

	public MegaMorphChan GetChannel(string name)
	{
		for ( int i = 0; i < chanBank.Count; i++ )
		{
			if ( chanBank[i].mName == name )
				return chanBank[i];
		}

		return null;
	}

	public int NumChannels()
	{
		return chanBank.Count;
	}

	public void SetPercent(int i, float percent)
	{
		if ( i >= 0 && i < chanBank.Count )
			chanBank[i].Percent = percent;
	}

	public void SetPercentLim(int i, float alpha)
	{
		if ( i >= 0 && i < chanBank.Count )
		{
			if ( chanBank[i].mUseLimit )
				chanBank[i].Percent = chanBank[i].mSpinmin + ((chanBank[i].mSpinmax - chanBank[i].mSpinmin) * alpha);
			else
				chanBank[i].Percent = alpha * 100.0f;
		}
	}

	public void SetPercent(int i, float percent, float speed)
	{
		chanBank[i].SetTarget(percent, speed);
	}

	public void ResetPercent(int[] channels, float speed)
	{
		for ( int i = 0; i < channels.Length; i++ )
		{
			int chan = channels[i];
			chanBank[chan].SetTarget(0.0f, speed);
		}
	}

	public float GetPercent(int i)
	{
		if ( i >= 0 && i < chanBank.Count )
			return chanBank[i].Percent;

		return 0.0f;
	}

	public void SetAnim(float t)
	{
		if ( animtype == MegaMorphAnimType.Bezier )
		{
			for ( int i = 0; i < chanBank.Count; i++ )
			{
				if ( chanBank[i].control != null )
				{
					if ( chanBank[i].control.Times != null )
					{
						if ( chanBank[i].control.Times.Length > 0 )
							chanBank[i].Percent = chanBank[i].control.GetFloat(t);  //, 0.0f, 100.0f);
					}
				}
			}
		}
		else
		{
			for ( int i = 0; i < chanBank.Count; i++ )
			{
				if ( chanBank[i].control != null )
				{
					if ( chanBank[i].control.Times != null )
					{
						if ( chanBank[i].control.Times.Length > 0 )
							chanBank[i].Percent = chanBank[i].control.GetHermiteFloat(t);   //, 0.0f, 100.0f);
					}
				}
			}
		}
	}

	[System.Serializable]
	public class MegaMorphBlend
	{
		public float t;
		public float weight;
	}

	public int numblends;
	public List<MegaMorphBlend> blends; // = new List<MegaMorphBlend>();

	public void SetAnimBlend(float t, float weight)
	{
		if ( blends == null )
		{
			blends = new List<MegaMorphBlend>();

			for ( int i = 0; i < 4; i++ )
			{
				blends.Add(new MegaMorphBlend());
			}
		}

		blends[numblends].t = t;
		blends[numblends].weight = weight;

		numblends++;
	}

	public void ClearBlends()
	{
		numblends = 0;
	}

	public void SetChannels()
	{
		float tweight = 0.0f;
		for ( int i = 0; i < numblends; i++ )
		{
			tweight += blends[i].weight;
		}

		for ( int b = 0; b < numblends; b++ )
		{
			for ( int c = 0; c < chanBank.Count; c++ )
			{
				if ( animtype == MegaMorphAnimType.Bezier )
				{
					if ( chanBank[c].control != null )
					{
						if ( chanBank[c].control.Times != null )
						{
							if ( chanBank[c].control.Times.Length > 0 )
							{
								if ( b == 0 )
									chanBank[c].Percent = chanBank[c].control.GetFloat(blends[b].t) * (blends[b].weight / tweight); //, 0.0f, 100.0f);
								else
									chanBank[c].Percent += chanBank[c].control.GetFloat(blends[b].t) * (blends[b].weight / tweight);    //, 0.0f, 100.0f);
							}
						}
					}
				}
				else
				{
					if ( chanBank[c].control != null )
					{
						if ( chanBank[c].control.Times != null )
						{
							if ( chanBank[c].control.Times.Length > 0 )
							{
								if ( b == 0 )
									chanBank[c].Percent = chanBank[c].control.GetHermiteFloat(blends[b].t) * (blends[b].weight / tweight);  //, 0.0f, 100.0f);
								else
									chanBank[c].Percent += chanBank[c].control.GetHermiteFloat(blends[b].t) * (blends[b].weight / tweight); //, 0.0f, 100.0f);
							}
						}
					}
				}
			}
		}
	}
}
