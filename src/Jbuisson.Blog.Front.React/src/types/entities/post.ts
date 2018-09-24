export interface IPost {
  Id: number;
  Title: string;
  CanonicalTitle: string;
  Author: string;
  PublishedAt: Date;
  Preview: string;
  Content: string;
  ViewsCount: number;
  CommentsCount: number;

  Comments: number[];
}
