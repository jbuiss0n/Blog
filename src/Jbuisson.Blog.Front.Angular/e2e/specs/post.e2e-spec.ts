import { browser, by, element } from 'protractor';

describe('the post page', () => {

  it('should fecth the blog from the title params', () => {
    browser.get('/this-is-the-first-blog-post').then(() =>
      expect(element(by.css('.blog-post-title')).getText()).toEqual('This is the first blog post'));

    browser.get('/this-is-the-second-blog-post').then(() =>
      expect(element(by.css('.blog-post-title')).getText()).toEqual('This is the second blog post'));

    browser.get('/this-is-the-third-blog-post').then(() =>
      expect(element(by.css('.blog-post-title')).getText()).toEqual('This is the third blog post'));
  });
});
