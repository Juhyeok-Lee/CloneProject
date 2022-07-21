public class Actor {

    // 멤버변수들의 접근자를 조정해주지 않으면, 다른 클래스에서 변수에 접근할 수 없다.
    public int id;
    public string name;
    public string title;
    public string weapon;
    public float strength;
    public int level;

    public string Talk()
    {
        return "대화를 걸었습니다.";
    }

    public string HasWeapon()
    {
        return weapon;
    }

    public void LevelUp()
    {
        level = level + 1;
    }

}
