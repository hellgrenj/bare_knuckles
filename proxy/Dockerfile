FROM haproxy:1.7
COPY ./haproxy.cfg /usr/local/etc/haproxy/haproxy.cfg
RUN mkdir -p /run/haproxy/
RUN mkdir -p /var/lib/haproxy/
EXPOSE 80
