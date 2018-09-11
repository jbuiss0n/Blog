import { browser, by, element } from 'protractor';

describe('the home page', () => {

  beforeAll(() => {
    browser.get('/');
  });

  it('should fecth blogs', () => {
    expect(element.all(by.css('home .blog-post')).count()).toEqual(3);
  });

  it('should bind blogs title with link to post page', () => {
    expect(element.all(by.css('home .blog-post .blog-post-title a')).get(0).getAttribute('href')).toEqual('http://localhost:4200/this-is-the-first-blog-post');
    expect(element.all(by.css('home .blog-post .blog-post-title a')).get(1).getAttribute('href')).toEqual('http://localhost:4200/this-is-the-second-blog-post');
    expect(element.all(by.css('home .blog-post .blog-post-title a')).get(2).getAttribute('href')).toEqual('http://localhost:4200/this-is-the-third-blog-post');
  });

  it('should bind blogs title', () => {
    expect(element.all(by.css('home .blog-post .blog-post-title')).get(0).getText()).toEqual('This is the first blog post');
    expect(element.all(by.css('home .blog-post .blog-post-title')).get(1).getText()).toEqual('This is the second blog post');
    expect(element.all(by.css('home .blog-post .blog-post-title')).get(2).getText()).toEqual('This is the third blog post');
  });

  it('should bind blogs preview', () => {
    expect(element.all(by.css('home .blog-post .blog-post-preview')).get(0).getText()).toEqual('This one is very basic.');
    expect(element.all(by.css('home .blog-post .blog-post-preview')).get(1).getText()).toEqual('This one got a lot of views and comments to test formatting.');
    expect(element.all(by.css('home .blog-post .blog-post-preview')).get(2).getText()).toEqual('This one has no views nor comments, to test conditionnal formatting.');
  });

  it('should bind the blogs published date formatted', () => {
    expect(element.all(by.css('home .blog-post .blog-post-meta')).get(0).getText()).toEqual('Sep 1, 2018');
    expect(element.all(by.css('home .blog-post .blog-post-meta')).get(1).getText()).toEqual('Sep 2, 2018');
    expect(element.all(by.css('home .blog-post .blog-post-meta')).get(2).getText()).toEqual('Sep 3, 2018');
  });

  it('should bind the blogs views count formatted', () => {
    expect(element.all(by.css('home .blog-post .blog-post-meta-views')).get(0).getText()).toEqual('10 views');
    expect(element.all(by.css('home .blog-post .blog-post-meta-views')).get(1).getText()).toEqual('10,000,000 views');
    expect(element.all(by.css('home .blog-post .blog-post-meta-views')).get(2).getText()).toEqual('0 views');
  });

  it('should bind the blogs comments count formatted', () => {
    expect(element.all(by.css('home .blog-post .blog-post-meta-comments')).get(0).getText()).toEqual('20 comments');
    expect(element.all(by.css('home .blog-post .blog-post-meta-comments')).get(1).getText()).toEqual('20,000 comments');
    expect(element.all(by.css('home .blog-post .blog-post-meta-comments')).get(2).getText()).toEqual('no comments');
  });

  it('should bind the blogs comments with anchor to comments', () => {
    expect(element.all(by.css('home .blog-post .blog-post-meta-comments')).get(0).getAttribute('href')).toEqual('http://localhost:4200/this-is-the-first-blog-post#comments');
    expect(element.all(by.css('home .blog-post .blog-post-meta-comments')).get(1).getAttribute('href')).toEqual('http://localhost:4200/this-is-the-second-blog-post#comments');
    expect(element.all(by.css('home .blog-post .blog-post-meta-comments')).get(2).getAttribute('href')).toEqual('http://localhost:4200/this-is-the-third-blog-post#comments');
  });
});
