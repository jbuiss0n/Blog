export interface IPostModel {
  id: number;
  title: string;
  preview: string;
  content: string;
  publishedAt: Date;
  viewsCount: number;
  commentsCount: number;
}
