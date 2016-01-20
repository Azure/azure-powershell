FROM ubuntu:14.04

# all in one RUN to produce less, smaller layers
RUN bash -c "\
	sudo apt-get -qqy update && \
	sudo apt-get -qqy upgrade && \
	sudo apt-get -qqy install wget libicu-dev libunwind8-dev libcurl3 libcurl4-gnutls-dev && \
	sudo apt-get clean && \
	sudo rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*"

RUN bash -c "\
	mkdir /opt/az && \
	cd /opt/az && \
	wget https://azurecludrops.blob.core.windows.net/drops/ubuntu.14.04-x64.latest.tar.gz && \
	tar xvzf ubuntu.14.04-x64.latest.tar.gz"

ENV PATH "$PATH:/opt/az/ubuntu.14.04-x64/"

WORKDIR /opt/az/ubuntu.14.04-x64/
