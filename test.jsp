<%@ page
language="java"
contentType="text/html; charset=UTF-8"
pageEncoding="UTF-8"
%><?xml version="1.0" encoding="utf-8"?>
<% request.setCharacterEncoding("utf-8"); %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"   
	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head><title>JSP TEST</title></head>
<body>
	<pre>
		클래스경로: <%=System.getProperty("java.class.path",".")%>
		라이브러리경로: <%=System.getProperty("java.library.path", ".")%>
		파라메터: <%=request.getParameter("param")%> ('한글'이라고 표기되어야 함)
		파일인코딩: <%=System.getProperty("file.encoding")%>
		시스템캐릭터셋: <%=java.nio.charset.Charset.defaultCharset().name()%>
		페이지캐릭터셋: <%=response.getCharacterEncoding()%>  
		서블릿 경로: <%=application.getRealPath("")%>
	</pre>
</body>
</html>