FROM graemef/docker-ubuntu-mono

ENV DNX_VERSION 1.0.0-rc1-final
ENV DNX_USER_HOME /opt/dnx

# Install DNX prerequisites
RUN apt-get update && \
    apt-get -qqy install \
    libunwind8 \
    gettext \
    libssl-dev \
    libcurl4-gnutls-dev \
    zlib1g \
    libicu-dev \
    uuid-dev \
    curl \
    unzip \
    jq

RUN curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_USER_HOME=$DNX_USER_HOME DNX_BRANCH=v$DNX_VERSION sh
   
RUN bash -c "source $DNX_USER_HOME/dnvm/dnvm.sh \
    && dnvm install $DNX_VERSION -r coreclr -alias default \
	&& dnvm alias default | xargs -i ln -s $DNX_USER_HOME/runtimes/{} $DNX_USER_HOME/runtimes/default"
   
ENV PATH $PATH:$DNX_USER_HOME/runtimes/default/bin 

ADD drop/clurun/ubuntu.14.04-x64 ubuntu.14.04-x64
ADD src/CLU test/clu
ADD tools tools
ADD examples examples

WORKDIR /test/clu

RUN bash -c "source $DNX_USER_HOME/dnvm/dnvm.sh \
    && nuget source enable -Name https://www.nuget.org/api/v2/ \
    && dnu restore \
    || dnvm use $DNX_VERSION -r coreclr"

ENV PATH /ubuntu.14.04-x64:$PATH
    
WORKDIR /test/clu/Commands.Common.ScenarioTest