public class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _commentsList = new List<Comment>();

    public Video()
    {

    }

    public int ReturnNumberComments()
    {
        return _commentsList.Count;
    }

}