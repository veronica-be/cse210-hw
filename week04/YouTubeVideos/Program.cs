using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        //videos
        Video video1 = new Video();
        video1._title = "The asbestos problem is worse than we thought";
        video1._author = "Element Chronicles";
        video1._length = 3285;

        Video video2 = new Video();
        video2._title = "Master the Art of Public Speaking: 5 Habits of Confident Communicators";
        video2._author = "Vocal Craft Academy";
        video2._length = 1682;

        Video video3 = new Video();
        video3._title = "Step-by-Step Embroidery for Beginners: 4 Stitches Everyone Should Know";
        video3._author = "The Stitching Studio";
        video3._length = 1045;

        Video video4 = new Video();
        video4._title = "The Chemistry of PFOAs: Why 'Forever Chemicals' Last Forever";
        video4._author = "Element Chronicles";
        video4._length = 3305;

        //comments

        //of video 1
        Comment comment1Video1 = new Comment();
        comment1Video1._name = "Oliver Vance";
        comment1Video1._text = "It is genuinely terrifying how a naturally occurring mineral can cause so much long-term hidden damage to the human body.";

        Comment comment2Video1 = new Comment();
        comment2Video1._name = "Elena Rostova";
        comment2Video1._text = "Excellent historical context regarding its massive industrial boom before the public health regulations were finally put into place.";

        Comment comment3Video1 = new Comment();
        comment3Video1._name = "Sarah Jenkins";
        comment3Video1._text = "This is exactly why public educational science content is so vital. I had no idea";

        Comment comment4Video1 = new Comment();
        comment4Video1._name = "Clara Montgomery";
        comment4Video1._text = "It is wild to think that a material praised for being completely fireproof turned out to have such a devastating hidden cost.";

        //of video 2
        Comment comment1Video2 = new Comment();
        comment1Video2._name = "Arthur P.";
        comment1Video2._text = "Using purposeful pauses instead of filling the silence with 'um' and 'uh' completely transformed my presentation.Thanks!";

        Comment comment2Video2 = new Comment();
        comment2Video2._name = "Sarah Pedelton";
        comment2Video2._text = "As an introvert, I always dreaded public speaking, but treating the audience like a collection of individual conversations makes it feel so much more manageable.";

        Comment comment3Video2 = new Comment();
        comment3Video2._name = "Simon Vance";
        comment3Video2._text = "I am definitely using these tips for my university defense next week!";

        //of video 3
        Comment comment1Video3 = new Comment();
        comment1Video3._name = "Beatrice Vance";
        comment1Video3._text = "The close-up camera angles showing exactly how to wrap the thread for the French knot are extremely helpful! I finally got it right on my third try.";

        Comment comment2Video3 = new Comment();
        comment2Video3._name = "Elena P.";
        comment2Video3._text = "I am using these techniques to customize my jacket.";

        Comment comment3Video3 = new Comment();
        comment3Video3._name = "Winston A.";
        comment3Video3._text = "This video is so peaceful and relaxing to watch. I might even try it.";

        Comment comment4Video3 = new Comment();
        comment4Video3._name = "Elena Montgomery";
        comment4Video3._text = "The color palette you chose for the floral sample pattern is absolutely beautiful.";

        //of video 4
        Comment comment1Video4 = new Comment();
        comment1Video4._name = "Ryan R.";
        comment1Video4._text = "This honestly unlocked a brand new fear for me. I am literally looking at my kitchen pans right now wondering if it's time to just throw them all out and switch to cast iron.";

        Comment comment2Video4 = new Comment();
        comment2Video4._name = "Emma W.";
        comment2Video4._text = "I literally just paused this video to go text my mom and tell her to stop using her scratched-up non-stick pans. This is wild.";

        Comment comment3Video4 = new Comment();
        comment3Video4._name = "Maya Lin";
        comment3Video4._text = "It's crazy how we invent these amazing, convenient materials and then only realize forty years later that they don't go away.";

        //adding comments to their respective videoList
        video1._commentsList.Add(comment1Video1);
        video1._commentsList.Add(comment2Video1);
        video1._commentsList.Add(comment3Video1);
        video1._commentsList.Add(comment4Video1);

        video2._commentsList.Add(comment1Video2);
        video2._commentsList.Add(comment2Video2);
        video2._commentsList.Add(comment3Video2);

        video3._commentsList.Add(comment1Video3);
        video3._commentsList.Add(comment2Video3);
        video3._commentsList.Add(comment3Video3);
        video3._commentsList.Add(comment4Video3);

        video4._commentsList.Add(comment1Video4);
        video4._commentsList.Add(comment2Video4);
        video4._commentsList.Add(comment3Video4);

        //Making List of all the videos
        List<Video> videos = [video1, video2, video3, video4];

        //Iterating for display
        int videoCounter = 1;
        foreach (var video in videos)
        {

            Console.WriteLine($"VIDEO {videoCounter}");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Total of comments: {video.ReturnNumberComments()}");

            int number = 1;
            foreach (var comment in video._commentsList)
            {
                Console.WriteLine($"COMMENT {number}");
                Console.WriteLine($"Name: {comment._name}");
                Console.WriteLine($"Comment: {comment._text}");
                number++;
            }

            Console.WriteLine();
            videoCounter++;
        }




    }
}