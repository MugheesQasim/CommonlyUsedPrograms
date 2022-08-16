private float WrapAngle(float angle)
{
  angle%=360;
  if(angle >180)
    return angle - 360;
  return angle;
}
